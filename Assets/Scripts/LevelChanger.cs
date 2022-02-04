using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelGenerator _generator;
    [SerializeField] private QuestionView _questionView;
    [SerializeField] private List<LevelData> _levels;

    private int _currentLevelIndex = 0;

    public event UnityAction AllLevelsCompleted;

    private void OnValidate()
    {
        if (_generator == null)
            _generator = FindObjectOfType<LevelGenerator>();

        if (_questionView == null)
            _questionView = FindObjectOfType<QuestionView>();
    }

    private void OnEnable()
    {
        _questionView.RightAnswerChosen += OnRightAnswerChosen;
    }

    private void OnDisable()
    {
        _questionView.RightAnswerChosen -= OnRightAnswerChosen;
    }

    private void Start()
    {
        _generator.GenerateLevel(_levels[_currentLevelIndex]);
    }

    private void OnRightAnswerChosen()
    {
        _currentLevelIndex++;
        if (_currentLevelIndex >= _levels.Count)
            AllLevelsCompleted?.Invoke();
        else
            _generator.GenerateLevel(_levels[_currentLevelIndex]);
    }
}
