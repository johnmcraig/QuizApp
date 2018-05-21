using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuizModel
    {
        public int Id { get; set; }
        [Display(Name = "Quiz Title:" )]
        public string Title { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public List<Question> Questions { get; set; }
    }
}
