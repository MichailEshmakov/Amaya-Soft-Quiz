using System;
using DG.Tweening;
using UnityEngine;

namespace TweenAnimation
{
    public class BounceTweenAnimator : TweenAnimator
    {
        [SerializeField] private Transform _animable;
        [SerializeField] private float _compression;
        [SerializeField] private float _extension;
        [SerializeField] private float _compressionPeriod;
        [SerializeField] private float _extensionPeriod;

        protected override Action<Action> CreateAnimation()
        {
            return (Action callback) =>
            {
                _animable.DOScale(-_compression, _compressionPeriod).SetRelative(true).OnComplete(() =>
                {
                    _animable.DOScale(_compression, _compressionPeriod).SetRelative(true).OnComplete(() =>
                    {
                        _animable.DOScale(_extension, _extensionPeriod).SetRelative(true).OnComplete(() =>
                        {
                            _animable.DOScale(-_extension, _extensionPeriod).SetRelative(true).OnComplete(() => callback?.Invoke());
                        });
                    });
                });
            };
        }
    }
}
