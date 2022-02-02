using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class Theme<T> : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private List<T> _answers;

        public string Name => _name;
        public IReadOnlyList<T> Answers => _answers;

        public Theme(string name, IReadOnlyList<T> answers)
        {
            _name = name;
            _answers = answers.ToList();
        }

        public Theme<object> ToObject()
        {
            IReadOnlyList<object> objectAnswers = _answers.Select(answer => answer as object).ToList();
            return new Theme<object>(_name, objectAnswers);
        }
    }
}

