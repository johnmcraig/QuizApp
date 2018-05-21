using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class QuestionMap
    {
        public QuestionMap(EntityTypeBuilder<Question> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Content).IsRequired();
        }
    }
}
