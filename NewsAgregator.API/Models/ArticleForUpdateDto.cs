using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAgregator.API.Models
{
    public class ArticleForUpdateDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
