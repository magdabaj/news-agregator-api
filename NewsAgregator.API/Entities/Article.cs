﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAgregator.API.Entities
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }
        public DateTimeOffset AddedDate { get; set; }
        public DateTimeOffset EditDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }

    }
}
