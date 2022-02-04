using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TweenAnimation
{
    public class FadeTweenAnimator : TweenAnimator
    {
        [SerializeField] private List<SpriteRenderer> _sprites;
        [SerializeField] private float _duration;
        [SerializeField] private bool _isIn;

        private int spritesFadeIned;

        protected override Action<Action> CreateAnimation()
        {
            spritesFadeIned = 0;
            return (Action callback) => _sprites.ForEach(sprite =>
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, _isIn ? 0 : 1);
                sprite.DOFade(_isIn ? 1 : 0, _duration).OnComplete(() => OnSpriteFadeIned(callback));
            });
        }

        private void OnSpriteFadeIned(Action callback)
        {
            spritesFadeIned++;
            if (spritesFadeIned >= _sprites.Count)
                callback?.Invoke();
        }

        [ContextMenu(nameof(SetDaughterSprites))]
        private void SetDaughterSprites()
        {
            _sprites = GetComponentsInChildren<SpriteRenderer>().ToList();
        }
    }
}