using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model
{
    public class Question
    {
        private Theme<object> _theme;
        private object[,] _answers;
        private object _rightAnswer;

        public Question(Theme<object> theme, int width, int height)
        {
            _answers = new object[width, height];
            _theme = theme;
            FillAnswers(_theme.Answers);
        }

        private bool IsRight(object answer)
        {
            return answer == _rightAnswer;
        }

        private void FillAnswers(IReadOnlyList<object> newAnswers)
        {
            if (_answers == null)
                throw new ArgumentNullException(nameof(_answers));

            List<object> shuffledAnswers = newAnswers.ToList();
            shuffledAnswers.Shuffle();
            _rightAnswer = shuffledAnswers[UnityEngine.Random.Range(0, shuffledAnswers.Count)];

            for (int i = 0; i < _answers.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _answers.GetUpperBound(1); j++)
                {
                    _answers[i, j] = shuffledAnswers[i + j];
                }
            }
        }
    }
}
