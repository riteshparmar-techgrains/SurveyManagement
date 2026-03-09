using SurveyManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Domain.Entities
{
    public class Question
    {
        public int Id { get; private set; }
        public string Text { get; private set; }

        public QuestionType Type { get; private set; }

        public Question(string text, QuestionType type)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new AggregateException("Question text can't be empty");

                Text = text;
                Type = type;
            }
        }
    }
}
