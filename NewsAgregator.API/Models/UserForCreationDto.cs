using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAgregator.API.Models
{
    public class UserForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public ICollection<ArticleForCreationDto> Articles { get; set; } = new List<ArticleForCreationDto>();
    }
}
