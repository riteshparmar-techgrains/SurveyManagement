using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyManagement.Domain.Entities
{
    public class Survey
    {
        public int Id { get; private set; }
        public string Title { get; private set; }


        private readonly List<Question> _questions = new();
        public IReadOnlyCollection<Question> Questions => _questions;

        public Survey(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Survey title can't be empty", nameof(title));

            Title = title;
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }
    }
}
