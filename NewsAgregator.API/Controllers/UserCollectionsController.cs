using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NewsAgregator.API.Helpers;
using NewsAgregator.API.Models;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{
    [ApiController]
    [Route("api/userscollections")]
    public class UserCollectionsController: ControllerBase
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;

        public UserCollectionsController(IArticleLibraryRepository articleLibraryRepository, IMapper mapper)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name ="GetAuthorCollection") ]
        public IActionResult GetUserCollection(
            [FromRoute] 
        [ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var userEntities = _articleLibraryRepository.GetUsers(ids);

            if(ids.Count() != userEntities.Count())
            {
                return NotFound();
            }

            var usersToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);

            return Ok(usersToReturn);
        }

        // array key: 1,2,3
        // composite key: key1=value1,key2=value2

        [HttpPost]
        public ActionResult<IEnumerable<UserDto>> CreateUserCollection(IEnumerable<UserForCreationDto> userCollection)
        {
            var userEntities = _mapper.Map<IEnumerable<Entities.User>>(userCollection);
            foreach(var user in userEntities)
            {
                _articleLibraryRepository.AddUser(user);
            }

            _articleLibraryRepository.Save();

            var userCollectionToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
            var idsAsString = string.Join(",", userCollectionToReturn.Select(u => u.Id));

            return CreatedAtRoute("GetAuthorCollection",
                new { ids = idsAsString },
                userCollectionToReturn);
        }
    }
}