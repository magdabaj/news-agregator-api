using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAgregator.API.Entities
{
    public class TagsArticles
    {
        [ForeignKey("ArticleId")] public Guid ArticleId { get; set; }
        [ForeignKey("TagId")] public Guid TagId { get; set; }
    }
}
