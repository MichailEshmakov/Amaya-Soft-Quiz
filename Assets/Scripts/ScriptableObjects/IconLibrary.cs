using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObjects
{
    public abstract class IconLibrary<T> : ScriptableObject, IIconLibrary where T : IIconMatch
    {
        [SerializeField] private List<T> _matches;

        public Type Type => _matches[0].Type;

        public IIconMatch GetMatch(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            IIconMatch result = _matches.FirstOrDefault(match => match.Value.Equals(value));
            if (result == null)
                throw new ArgumentOutOfRangeException(nameof(value));

            return result;
        }
    }

    [Serializable]
    public abstract class IconMatch<T> : IIconMatch
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private T _value;
        [SerializeField] private float _rotation;

        public Sprite Sprite => _sprite;
        public object Value => _value;
        public Type Type => typeof(T);
        public float Rotation => _rotation;
    }

    public interface IIconMatch
    {
        Sprite Sprite { get; }
        object Value { get; }
        Type Type { get; }
        float Rotation { get; }
    }
}
