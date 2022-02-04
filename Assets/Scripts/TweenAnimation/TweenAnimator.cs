using System;
using UnityEngine;
using UnityEngine.Events;

namespace TweenAnimation
{
    public abstract class TweenAnimator : MonoBehaviour
    {
        private Action<Action> _animation;
        private bool _isPlaying;

        public event UnityAction Played;

        private void Awake()
        {
            _animation = CreateAnimation();
        }

        public bool TryPlay()
        {
            if (_isPlaying == false)
            {
                _isPlaying = true;
                _animation?.Invoke(GetCallback());
                return true;
            }
            else
            {
                return false;
            }
        }

        protected abstract Action<Action> CreateAnimation();

        private Action GetCallback()
        {
            return () =>
            {
                _isPlaying = false;
                Played?.Invoke();
            };
        }
    }
}
