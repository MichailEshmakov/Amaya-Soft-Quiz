using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerView : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    public void Init(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
