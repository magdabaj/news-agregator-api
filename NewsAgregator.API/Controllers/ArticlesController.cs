using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsAgregator.API.Models;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/articles")]
    public class ArticlesController: ControllerBase
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleLibraryRepository articleLibraryRepository, IMapper mapper)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArticleDto>> GetArticlesForUser(Guid userId)
        {
            if (!_articleLibraryRepository.UserExists(userId))
            {
                return NotFound();
            }

            var articlesForUserFromRepo = _articleLibraryRepository.GetArticles(userId);

            return Ok(_mapper.Map<IEnumerable<ArticleDto>>(articlesForUserFromRepo));
        }

        [HttpGet("{articleId}", Name = "GetArticleForUser")]
        public ActionResult<ArticleDto> GetArticleForUser(Guid userId, Guid articleId)
        {
            if (!_articleLibraryRepository.UserExists(userId))
            {
                return NotFound();
            }

            var articleFromRepo = _articleLibraryRepository.GetArticle(userId, articleId);

            if(articleFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ArticleDto>(articleFromRepo));
        }


        [HttpPost]
        public ActionResult<ArticleDto> CreateArticleForUser(Guid userId, ArticleForCreationDto article )
        {
            if (!_articleLibraryRepository.UserExists(userId))
            {
                return NotFound();
            }

            var articleEntity = _mapper.Map<Entities.Article>(article);
            _articleLibraryRepository.AddArticle(userId, articleEntity);
            _articleLibraryRepository.Save();

            var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);
            return CreatedAtRoute("GetArticleForUser",
                new { userId = userId, articleId = articleToReturn.Id },
                articleToReturn);
        }

        [HttpPut("{articleId}")]
        public ActionResult UpdateArticleForUser(Guid userId,
            Guid articleId,
            ArticleForUpdateDto article)
        {
            if (!_articleLibraryRepository.UserExists(userId))
            {
                return NotFound();
            }

            var articleForUserFromRepo = _articleLibraryRepository.GetArticle(userId, articleId);

            if(articleForUserFromRepo == null)
            {
                return NotFound();
            }

            //map the entity to a CourseForUpdateDto
            // apply the upadted filed values to that dto
            // map the CourseForUpdateDto back to an entity
            _mapper.Map(article, articleForUserFromRepo);

            _articleLibraryRepository.UpdateArticle(articleForUserFromRepo);
            _articleLibraryRepository.Save();
            return NoContent();
        }
    }
}
