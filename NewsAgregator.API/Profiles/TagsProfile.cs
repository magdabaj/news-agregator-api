using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace NewsAgregator.API.Profiles
{
    public class TagsProfile: Profile
    {
        public TagsProfile()
        {
            CreateMap<Entities.Tag, Models.TagDto>();
        }
    }
}
