using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class BounceTweenAnimator : TweenAnimator
{
    [SerializeField] private Transform _animablePart;
    [SerializeField] private float _compression;
    [SerializeField] private float _extension;
    [SerializeField] private float _period;

    protected override Action<Action> CreateAnimation()
    {
        return (Action callback) =>
        {
            _animablePart.DOScale(-_compression, _period).SetRelative(true).OnComplete(() =>
            {
                _animablePart.DOScale(_compression, _period).SetRelative(true).OnComplete(() =>
                {
                    _animablePart.DOScale(_extension, _period).SetRelative(true).OnComplete(() =>
                    {
                        _animablePart.DOScale(-_extension, _period).SetRelative(true).OnComplete(() => callback?.Invoke());
                    });
                });
            });
        };
    }
}
