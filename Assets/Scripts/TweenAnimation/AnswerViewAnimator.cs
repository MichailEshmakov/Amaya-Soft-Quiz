using UnityEngine;
using UnityEngine.Events;

namespace TweenAnimation
{
    public class AnswerViewAnimator : MonoBehaviour
    {
        [SerializeField] private WrongTweenAnimator _wrongTween;
        [SerializeField] private BounceTweenAnimator _bounceTween;

        public event UnityAction RightPlayed;

        private void OnEnable()
        {
            _bounceTween.Played += OnBounceTweenPlayed;
        }

        private void OnDisable()
        {
            _bounceTween.Played -= OnBounceTweenPlayed;
        }

        public void TryPlayWrong()
        {
            _wrongTween.TryPlay();
        }

        public bool TryPlayRight()
        {
            return _bounceTween.TryPlay();
        }

        private void OnBounceTweenPlayed()
        {
            RightPlayed?.Invoke();
        }
    }
}
