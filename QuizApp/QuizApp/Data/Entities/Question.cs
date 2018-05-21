using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data.Entities
{
    public class Question : BaseEntity
    {
        [JsonIgnore]
        public Quiz Quiz { get; set; } //link back to the questions to refere to the questions are attached to
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
