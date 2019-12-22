using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NewsAgregator.API.Entities;
using NewsAgregator.API.Models;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/articles")]
    public class ArticlesController: ControllerBase
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly ITagLibraryRepository _tagLibraryRepository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleLibraryRepository articleLibraryRepository, IMapper mapper, ITagLibraryRepository tagLibraryRepository)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));
            _tagLibraryRepository = tagLibraryRepository ??
                throw new ArgumentNullException(nameof(tagLibraryRepository));
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


        [HttpPost("{tagId}")]
        public ActionResult<ArticleDto> CreateArticleForUser(Guid userId, ArticleForCreationDto article, Guid tagId )
        {
            if (!_articleLibraryRepository.UserExists(userId) ||
                !_tagLibraryRepository.TagExists(tagId))
            {
                return NotFound();
            }

            var articleEntity = _mapper.Map<Entities.Article>(article);
            _articleLibraryRepository.AddArticle(userId, articleEntity, tagId);
            _articleLibraryRepository.Save();

            var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);
            return CreatedAtRoute("GetArticleForUser",
                new { userId = userId, articleId = articleToReturn.Id },
                articleToReturn);
        }

        [HttpPut("{articleId}")]
        public IActionResult UpdateArticleForUser(Guid userId,
            Guid articleId,
            ArticleForUpdateDto article, Guid tagId)
        {
            if (!_articleLibraryRepository.UserExists(userId))
            {
                return NotFound();
            }

            var articleForUserFromRepo = _articleLibraryRepository.GetArticle(userId, articleId);

            if(articleForUserFromRepo == null)
            {
                var articleToAdd = _mapper.Map<Article>(article);
                articleToAdd.Id = articleId;

                _articleLibraryRepository.AddArticle(userId, articleToAdd, tagId);
                _articleLibraryRepository.Save();

                var articleToReturn = _mapper.Map<ArticleDto>(articleToAdd);

                return CreatedAtRoute("GetArticleForUser",
                    new {userId, articleId = articleToReturn.Id},
                    articleToReturn);
            }

            //map the entity to a CourseForUpdateDto
            // apply the upadted filed values to that dto
            // map the CourseForUpdateDto back to an entity
            _mapper.Map(article, articleForUserFromRepo);

            _articleLibraryRepository.UpdateArticle(articleForUserFromRepo);
            _articleLibraryRepository.Save();
            return NoContent();
        }

        [HttpPatch("{articleId}")]
        public IActionResult PartiallyUpdateArticleForUser(Guid userId,
            Guid articleId,
            Guid tagId,
            JsonPatchDocument<ArticleForUpdateDto> patchDocument)
        {
            if (!_articleLibraryRepository.UserExists((userId)))
            {
                return NotFound();
            }

            var articleForUserFromRepo = _articleLibraryRepository.GetArticle(userId, articleId);

            if (articleForUserFromRepo == null)
            {
                var articleDto = new ArticleForUpdateDto();
                patchDocument.ApplyTo(articleDto, ModelState);

                if (!TryValidateModel(articleDto))
                {
                    return ValidationProblem(ModelState);
                }

                var articleToAdd = _mapper.Map<Article>(articleDto);
                articleToAdd.Id = articleId;

                _articleLibraryRepository.AddArticle(userId, articleToAdd, tagId);
                _articleLibraryRepository.Save();

                var articleToReturn = _mapper.Map<ArticleDto>(articleToAdd);

                return CreatedAtRoute("GetArticleForUser",
                    new {userId, articleId = articleToReturn.Id},
                    articleToReturn);
            }

            var articleToPatch = _mapper.Map<ArticleForUpdateDto>(articleForUserFromRepo);
            // add validation
            patchDocument.ApplyTo(articleToPatch, ModelState);

            if (!TryValidateModel(articleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(articleToPatch, articleForUserFromRepo);

            _articleLibraryRepository.UpdateArticle(articleForUserFromRepo);

            _articleLibraryRepository.Save();

            return NoContent();
        }

        [HttpDelete("{articleId}")]
        public ActionResult DeleteArticleForUser(Guid userId, Guid articleId)
        {
            if (!_articleLibraryRepository.UserExists(userId))
            {
                return NotFound();
            }

            var articleForUserFromRepo = _articleLibraryRepository.GetArticle(userId, articleId);

            if (articleForUserFromRepo == null)
            {
                return NotFound();
            }
            
            _articleLibraryRepository.DeleteArticle(articleForUserFromRepo);
            _articleLibraryRepository.Save();

            return NoContent();
        }

        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult) options.Value.InvalidModelStateResponseFactory(ControllerContext);
            return base.ValidationProblem(modelStateDictionary);
        }
    }
}
