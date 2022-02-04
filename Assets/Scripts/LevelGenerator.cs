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

    private void Start()
    {
        GenerateLevel(_levels[0]);
    }

    public void GenerateLevel(LevelData data)
    {
        Type type = data.Theme.Type;
        Question question = new Question(data.Theme, data.Width, data.Height);
        List<AnswerView> answerViews = new List<AnswerView>();
        for (int i = 0; i < data.Width; i++)
        {
            for (int j = 0; j < data.Height; j++)
            {
                AnswerView newAnswerView = Instantiate(_answerViewPrefab);
                object answerValue = question.GetAnswer(i, j);
                Sprite sprite = _iconMatcher.FindSprite(answerValue, type);
                newAnswerView.Init(sprite, answerValue);
                answerViews.Add(newAnswerView);
            }
        }

        _tableConstructor.ConstructTable(answerViews.Select(answer => answer.transform).ToList(), data.Width, data.Height);
        _questionView.Init(question, answerViews);
    }
}
