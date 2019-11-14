using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NewsAgregator.API.ValidationAttributes;

namespace NewsAgregator.API.Models
{
    [ArticleTitleMustBeDifferentFromUrlAttribute(ErrorMessage ="Title must be different from url")]
    public class ArticleForCreationDto//: IValidatableObject
    {
        [Required(ErrorMessage ="You should fill out a title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You should fill out the url")]
        public string Url { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Url)
        //    {
        //        yield return new ValidationResult(
        //            "The provided description should be different from the title.",
        //            new[] { "ArticleForCreationDto" });
        //    }
        //}
    }
}
