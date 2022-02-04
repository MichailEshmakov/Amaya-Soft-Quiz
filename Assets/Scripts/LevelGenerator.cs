using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AnswerView _answerViewPrefab;
    [SerializeField] private IconMatcher _iconMatcher;
    [SerializeField] private TableConstructor _tableConstructor;
    [SerializeField] private QuestionView _questionView;

    public event UnityAction<string> Generated;

    private List<AnswerView> _answerViews;

    public void GenerateLevel(LevelData data)
    {
        DestroyLevel();
        Question question = new Question(data.Theme, data.Width, data.Height);
        _answerViews = InitAnswerViews(data.Width, data.Height, question, data.Theme.Type);
        _tableConstructor.ConstructTable(_answerViews.Select(answer => answer.transform).ToList(), data.Width, data.Height);
        _questionView.Init(question, _answerViews);
        Generated?.Invoke(question.RigthAnswer);
    }

    private List<AnswerView> InitAnswerViews(int width, int height, Question question, Type type)
    {
        List<AnswerView> answerViews = new List<AnswerView>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                AnswerView newAnswerView = Instantiate(_answerViewPrefab, transform);
                object answerValue = question.GetAnswer(i, j);
                IIconMatch iconMatch = _iconMatcher.FindMatch(answerValue, type);
                newAnswerView.Init(iconMatch);
                answerViews.Add(newAnswerView);
            }
        }

        return answerViews;
    }

    private void DestroyLevel()
    {
        _questionView.Uninit();
        if (_answerViews != null)
            _answerViews.ForEach(view => Destroy(view.gameObject));
    }
}
