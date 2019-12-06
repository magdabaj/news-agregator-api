using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsAgregator.API.Models;
using NewsAgregator.API.ResourceParameters;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticlesAllCollectionController : ControllerBase
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;

        public ArticlesAllCollectionController(IArticleLibraryRepository articleLibraryRepository,
            IMapper mapper, IPropertyMappingService propertyMappingService)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService ??
                throw new ArgumentNullException(nameof(propertyMappingService));
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult<IEnumerable<ArticleDto>> GetAllArticles()
        //{
        //    var articlesFromRepo = _articleLibraryRepository.GetAllArticles();

        //    return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articlesFromRepo));
        //}


        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<ArticleDto>> GetArticles([FromQuery] ArticlesResourceParameters articlesResourceParameters)
        {
            var articlesFromRepo = _articleLibraryRepository.GetAllArticles(articlesResourceParameters);

            return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articlesFromRepo));
        }
    }
}
