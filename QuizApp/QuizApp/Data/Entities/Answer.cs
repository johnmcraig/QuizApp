using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data.Entities
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
}
