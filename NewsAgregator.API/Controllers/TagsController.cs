using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsAgregator.API.Models;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagsController: ControllerBase
    {
        private readonly ITagLibraryRepository _tagLibraryRepository;
        private readonly IMapper _mapper;

        public TagsController(ITagLibraryRepository tagLibraryRepository, IMapper mapper)
        {
            _tagLibraryRepository = tagLibraryRepository ??
                                    throw new ArgumentNullException(nameof(tagLibraryRepository));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<TagDto>> GetTags()
        {
            var tagsFromRepo = _tagLibraryRepository.GetTags();

            return Ok(_mapper.Map<IEnumerable<TagDto>>(tagsFromRepo));
        }

  
    }
}
