using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private AnswerViewAnimator _animator;

    private object _value;

    public object Value => _value;

    public event UnityAction<AnswerView> Click;
    public event UnityAction RightAnimationPlayed;
    public event UnityAction RightAnimationPlaying;

    private void OnEnable()
    {
        _animator.RightPlayed += OnRightAnimationPlayed;
    }

    private void OnDisable()
    {
        _animator.RightPlayed -= OnRightAnimationPlayed;
    }

    private void OnMouseDown()
    {
        Click?.Invoke(this);
    }

    public void Init(Sprite sprite, object value)
    {
        _spriteRenderer.sprite = sprite;
        _value = value;
    }

    public void TryPlayWrongAnimation()
    {
        _animator.TryPlayWrong();
    }

    public void TryPlayRightAnimation()
    {
        if (_animator.TryPlayRight())
            RightAnimationPlaying?.Invoke();
    }

    private void OnRightAnimationPlayed()
    {
        RightAnimationPlayed?.Invoke();
    }
}
