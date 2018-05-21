using Newtonsoft.Json;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Quiz Quiz { get; set; } //link back to the questions to refere to the questions are attached to
        [Display(Name = "Question to Ask: ")]
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
