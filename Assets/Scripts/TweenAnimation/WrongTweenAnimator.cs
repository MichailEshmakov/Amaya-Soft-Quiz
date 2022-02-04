using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WrongTweenAnimator : TweenAnimator
{
    [SerializeField] private Transform _wrongAnimablePart;
    [SerializeField] private float _offset;
    [SerializeField] private float _wrongAnimationPeriod;

    protected override Action<Action> CreateAnimation()
    {
        return (Action callback) =>
        {
            _wrongAnimablePart.DOMoveX(_offset, _wrongAnimationPeriod).SetRelative(true).OnComplete(() =>
            {
                _wrongAnimablePart.DOMoveX(-2 * _offset, _wrongAnimationPeriod * 2).SetRelative(true).OnComplete(() =>
                {
                    _wrongAnimablePart.DOMoveX(_offset, _wrongAnimationPeriod).SetRelative(true).OnComplete(() => callback?.Invoke());
                });
            });
        };
    }
}
