using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _background;
    [SerializeField] private float _backgroundAlpha;
    [SerializeField] private float _fadeSpeed;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void Start()
    {
        StartCoroutine(FadeInBackground());
    }

    private IEnumerator FadeInBackground()
    {
        while (_background.color.a != _backgroundAlpha)
        {
            _background.color = new Color(_background.color.r, _background.color.g, _background.color.b,
                Mathf.MoveTowards(_background.color.a, _backgroundAlpha, _fadeSpeed * Time.deltaTime));
            yield return null;
        }
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
