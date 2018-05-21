using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class QuizMap
    {
        public QuizMap(EntityTypeBuilder<Quiz> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.Author).IsRequired();
            entityBuilder.Property(t => t.PublishDate).IsRequired();
        }
    }
}
