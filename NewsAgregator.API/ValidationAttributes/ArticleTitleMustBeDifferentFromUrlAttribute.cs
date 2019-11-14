using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NewsAgregator.API.Models;

namespace NewsAgregator.API.ValidationAttributes
{
    public class ArticleTitleMustBeDifferentFromUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var article = (ArticleForCreationDto)validationContext.ObjectInstance;

            if(article.Title == article.Url)
            {
                return new ValidationResult(ErrorMessage,
                    new[] { nameof(ArticleForCreationDto) });
            }

            return ValidationResult.Success;
        }
    }
}
