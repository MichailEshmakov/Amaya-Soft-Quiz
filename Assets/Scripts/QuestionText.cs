using System.Collections;
using UnityEngine;
using TMPro;

namespace View
{
    public class QuestionText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private string _findingSentence;
        [SerializeField] private float _appearingTime;
        [SerializeField] private LevelGenerator _levelGenerator;

        private Coroutine FadingIn;

        private void OnValidate()
        {
            if (_levelGenerator == null)
                _levelGenerator = FindObjectOfType<LevelGenerator>();
        }

        private void OnEnable()
        {
            _levelGenerator.Generated += OnGenerated;
        }

        private void OnDisable()
        {
            if (FadingIn != null)
            {
                StopCoroutine(FadingIn);
                FadingIn = null;
                _text.alpha = 1;
            }

            _levelGenerator.Generated -= OnGenerated;
        }

        private void OnGenerated(string rightAnswer)
        {
            _text.text = $"{_findingSentence}{rightAnswer}";
            _text.alpha = 0;
            if (FadingIn == null)
                FadingIn = StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            if (_appearingTime == 0)
            {
                _text.alpha = 1;
                FadingIn = null;
                yield break;
            }
            else
            {
                float speed = 1f / _appearingTime;
                while (_text.alpha < 1)
                {
                    _text.alpha = Mathf.MoveTowards(_text.alpha, 1, speed * Time.deltaTime);
                    yield return null;
                }
            }

            FadingIn = null;
        }
    }
}
