using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Model;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private AnswerView _answerViewPrefab;
    [SerializeField] private IconMatcher _iconMatcher;
    [SerializeField] private List<LevelData> _levels;
    [SerializeField] private TableConstructor _tableConstructor;
    [SerializeField] private QuestionView _questionView;
    [SerializeField] private QuestionText _questionText;

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
        _questionText.Init(question.RigthAnswer);
    }

    private List<AnswerView> InitAnswerViews(int width, int height, Question question, Type type)
    {
        List<AnswerView> answerViews = new List<AnswerView>();
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                AnswerView newAnswerView = Instantiate(_answerViewPrefab);
                object answerValue = question.GetAnswer(i, j);
                Sprite sprite = _iconMatcher.FindSprite(answerValue, type);
                newAnswerView.Init(sprite, answerValue);
                answerViews.Add(newAnswerView);
            }
        }

        return answerViews;
    }
}
