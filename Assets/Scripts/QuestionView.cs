using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace View
{
    public class QuestionView : MonoBehaviour
    {
        private Question _question;
        private IReadOnlyList<AnswerView> _answerViews;

        public event UnityAction RightAnswerChosen;

        private void OnDestroy()
        {
            foreach (AnswerView answer in _answerViews)
            {
                answer.Click -= OnAnswerClick;
                answer.RightAnimationPlayed -= OnRightAnimationPlayed;
            }
        }

        public void Init(Question question, IReadOnlyList<AnswerView> answerViews)
        {
            _question = question;
            _answerViews = answerViews;
            foreach (AnswerView answer in _answerViews)
            {
                answer.Click += OnAnswerClick;
                answer.RightAnimationPlayed += OnRightAnimationPlayed;
            }
        }

        public void Uninit()
        {
            if (_answerViews != null)
            {
                foreach (AnswerView answer in _answerViews)
                {
                    answer.Click -= OnAnswerClick;
                    answer.RightAnimationPlayed -= OnRightAnimationPlayed;
                }
            }
        }

        private void OnRightAnimationPlayed()
        {
            foreach (AnswerView answer in _answerViews)
            {
                answer.enabled = false;
            }
            RightAnswerChosen?.Invoke();
        }

        private void OnAnswerClick(AnswerView answerView)
        {
            if (_question.IsRight(answerView.Value))
                answerView.TryPlayRightAnimation();
            else
                answerView.TryPlayWrongAnimation();
        }
    }
}
