using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

namespace ScriptableObjects
{
    public abstract class LevelData : ScriptableObject
    {
        [SerializeField] private int _height;
        [SerializeField] private int _width;

        public int Height => _height;
        public int Width => _width;
        public abstract ITheme Theme { get; }
    }
}


