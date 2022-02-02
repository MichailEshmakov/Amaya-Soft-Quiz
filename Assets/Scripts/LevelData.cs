using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public abstract class LevelData : ScriptableObject
    {
        [SerializeField] private int _height;
        [SerializeField] private int _width;

        abstract protected Theme<object> GetTheme();
    }
}
