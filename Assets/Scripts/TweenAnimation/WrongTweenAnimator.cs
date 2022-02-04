using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WrongTweenAnimator : TweenAnimator
{
    [SerializeField] private Transform _animable;
    [SerializeField] private float _offset;
    [SerializeField] private float _period;

    protected override Action<Action> CreateAnimation()
    {
        return (Action callback) =>
        {
            _animable.DOMoveX(_offset, _period).SetRelative(true).OnComplete(() =>
            {
                _animable.DOMoveX(-2 * _offset, _period * 2).SetRelative(true).OnComplete(() =>
                {
                    _animable.DOMoveX(_offset, _period).SetRelative(true).OnComplete(() => callback?.Invoke());
                });
            });
        };
    }
}
