using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimator : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private BounceTweenAnimator _tableBounceTween;

    private void OnValidate()
    {
        if (_levelGenerator == null)
            _levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    private void OnEnable()
    {
        _levelGenerator.Generated += OnLevelGenerated;
    }

    private void OnDisable()
    {
        _levelGenerator.Generated -= OnLevelGenerated;
    }

    private void OnLevelGenerated(string rightAnswer)
    {
        _tableBounceTween.TryPlay();
    }
}
