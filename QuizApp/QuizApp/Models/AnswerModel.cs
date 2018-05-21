using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        [Display(Name = "Answer to Question: ")]
        public string Content { get; set; }
        [Display(Name = "Is it Correct? Select box if 'Yes': ")]
        public bool IsCorrect { get; set; }
    }
}
