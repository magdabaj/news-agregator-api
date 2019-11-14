using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace NewsAgregator.API.Profiles
{
    public class ArticlesProfile: Profile
    {
        public ArticlesProfile()
        {
            CreateMap<Entities.Article, Models.ArticleDto>();
            CreateMap<Models.ArticleForCreationDto, Entities.Article>();
            CreateMap<Models.ArticleForUpdateDto, Entities.Article>();
        }
    }
}
