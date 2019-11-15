using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsAgregator.API.Helpers;
using NewsAgregator.API.Models;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController: ControllerBase
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;

        public UsersController(IArticleLibraryRepository articleLibraryRepository, IMapper mapper)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [HttpHead ]
        public ActionResult<IEnumerable<UserDto>> GetUsers(string email, string searchQuery)
        {
            var usersFromRepo = _articleLibraryRepository.GetUsers(email, searchQuery);
            
            return Ok(_mapper.Map<IEnumerable<UserDto>>(usersFromRepo));
        }

        [HttpGet("{userId}", Name = "GetUser")]
        public ActionResult<UserDto> GetUser(Guid userId)
        {
            var userFromRepo = _articleLibraryRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<Entities.User>(user);
            _articleLibraryRepository.AddUser(userEntity);
            _articleLibraryRepository.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return CreatedAtRoute("GetUser",
                new { userId = userToReturn.Id },
                userToReturn);
        }

        [HttpOptions]
        public IActionResult GetUsersOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(Guid userId)
        {
            var userFromRepo = _articleLibraryRepository.GetUser(userId);

            if (userFromRepo == null)
            {
                return NotFound();
            }

            _articleLibraryRepository.DeleteUser(userFromRepo);

            _articleLibraryRepository.Save();

            return NoContent();
        }

    }
}
