using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Model;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AnswerView _answerViewPrefab;
    [SerializeField] private IconMatcher _iconMatcher;
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private TableConstructor _tableConstructor;
    [SerializeField] private QuestionView _questionView;

    public event UnityAction<string> Generated;

    private void Start()
    {
        GenerateLevel(_levels[0]);
    }

    public void GenerateLevel(LevelData data)
    {
        Question question = new Question(data.Theme, data.Width, data.Height);
        List<AnswerView> answerViews = InitAnswerViews(data.Width, data.Height, question, data.Theme.Type);
        _tableConstructor.ConstructTable(answerViews.Select(answer => answer.transform).ToList(), data.Width, data.Height);
        _questionView.Init(question, answerViews);
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
                Sprite sprite = _iconMatcher.FindSprite(answerValue, type);
                newAnswerView.Init(sprite, answerValue);
                answerViews.Add(newAnswerView);
            }
        }

        return answerViews;
    }
}
