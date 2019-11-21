using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAgregator.API.Helpers;
using NewsAgregator.API.Models;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{


    [ApiController]
    [Authorize]
    [Route("api/users")]
    public class UsersController: Controller
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;
        //private readonly IOptions<JwtAuthentication> _jwtAuthentication;
        //private object jwtAuthentication;

        public UsersController(IArticleLibraryRepository articleLibraryRepository, IMapper mapper)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            //_jwtAuthentication = jwtAuthentication ??
            //    throw new ArgumentNullException(nameof(jwtAuthentication));
        }

        [HttpGet]
        [HttpHead ]
        [AllowAnonymous]
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

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult GenerateToken([FromBody]UserAuthenticateDto model)
        { 
            var userFromRepo = _articleLibraryRepository.Authenticate(model.Email, model.Password);
            // TODO use your actual logic to validate a user
            if (userFromRepo == null)
                return BadRequest("Username or password is invalid");

            Console.WriteLine(userFromRepo.Token);

            return Ok(userFromRepo);
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
