using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class Theme<T> : ScriptableObject, ITheme
    {
        [SerializeField] private string _name;
        [SerializeField] private List<T> _answers;

        public string Name => _name;
        public IReadOnlyList<object> Answers => _answers.Select(answer => answer as object).ToList();
        public Type Type => typeof(T);

        public Theme(string name, IReadOnlyList<T> answers)
        {
            _name = name;
            _answers = answers.ToList();
        }
    }

    public interface ITheme
    {
        string Name { get; }
        IReadOnlyList<object> Answers { get; }
        Type Type { get; }
}
}

