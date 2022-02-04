using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _findingSentence;

    public void Init(string rightAnswer)
    {
        _text.text = $"{_findingSentence}{rightAnswer}";
    }
}
