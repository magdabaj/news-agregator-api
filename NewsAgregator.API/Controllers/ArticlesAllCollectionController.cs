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
    [Route("api/articles")]
    public class ArticlesAllCollectionController : ControllerBase
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;

        public ArticlesAllCollectionController(IArticleLibraryRepository articleLibraryRepository,
            IMapper mapper)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ArticleDto>> GetAllArticles()
        {
            var articlesFromRepo = _articleLibraryRepository.GetAllArticles();

            return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articlesFromRepo));
        }
    }
}
