using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class AnswerMap
    {
        public AnswerMap(EntityTypeBuilder<Answer> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Content);
            entityBuilder.Property(t => t.IsCorrect);
        }
    }
}
