using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongatsParticles : MonoBehaviour
{
    [SerializeField] private AnswerView _answerView;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _answerView.RightAnimationPlaying += OnRightAnimationPlaying;
    }

    private void OnDisable()
    {
        _answerView.RightAnimationPlaying -= OnRightAnimationPlaying;
    }

    private void OnRightAnimationPlaying()
    {
        _particleSystem.Play();
    }
}
