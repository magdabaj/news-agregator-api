using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsAgregator.API.Entities;
using NewsAgregator.API.Helpers;
using NewsAgregator.API.Models;
using NewsAgregator.API.ResourceParameters;
using NewsAgregator.API.Services;

namespace NewsAgregator.API.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController: Controller
    {
        private readonly IArticleLibraryRepository _articleLibraryRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyMappingService _propertyMappingService;

        public UsersController(IArticleLibraryRepository articleLibraryRepository, IMapper mapper,
            IPropertyMappingService propertyMappingService)
        {
            _articleLibraryRepository = articleLibraryRepository ??
                throw new ArgumentNullException(nameof(articleLibraryRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _propertyMappingService = propertyMappingService ??
                                      throw new ArgumentNullException(nameof(propertyMappingService));
        }

        [HttpGet(Name = "GetUsers")]
        [HttpHead]
        //[Authorize(Roles = Role.Admin)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<UserDto>> GetUsers([FromQuery] 
            UsersResourceParameters usersResourceParameters
            )
        {
            if (!_propertyMappingService.ValidMappingExistsFor<UserDto, User>(usersResourceParameters.OrderBy))
            {
                return BadRequest();
            }

            var usersFromRepo = _articleLibraryRepository.GetUsers(usersResourceParameters);
            var previousPageLink = usersFromRepo.HasPrevious
                ? CreateUsersResourceUri(usersResourceParameters,
                    ResourceUriTypes.PreviousPage)
                : null;

            var nextPageLink = usersFromRepo.HasNext
                ? CreateUsersResourceUri(usersResourceParameters,
                    ResourceUriTypes.NextPage)
                : null;

            var paginationMetadata = new
            {
                totalCount = usersFromRepo.TotalCount,
                pageSize = usersFromRepo.PageSize,
                currentPage = usersFromRepo.CurrentPage,
                totalPages = usersFromRepo.TotalPages,
                previousPageLink,
                nextPageLink,
            };

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

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
        [AllowAnonymous]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = _mapper.Map<User>(user);
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
           
            if (userFromRepo == null)
                return BadRequest("Username or password is invalid");

            //Console.WriteLine(userFromRepo.Token);

            return Ok(userFromRepo);
        }


        [HttpOptions]
        public IActionResult GetUsersOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        //[Authorize(Roles = Role.Admin)]
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

        private string CreateUsersResourceUri(
            UsersResourceParameters usersResourceParameters,
            ResourceUriTypes type)
        {
            switch (type)
            {
                case ResourceUriTypes.PreviousPage:
                    return Url.Link("GetUsers",
                        new
                        {
                            orderBy = usersResourceParameters.OrderBy,
                            pageNumber = usersResourceParameters.PageNumber - 1,
                            pageSize = usersResourceParameters.PageSize,
                            Email = usersResourceParameters.Email,
                            searchQuery = usersResourceParameters.SearchQuery,
                        });
                case ResourceUriTypes.NextPage:
                    return Url.Link("GetUsers",
                        new
                        {
                            orderBy = usersResourceParameters.OrderBy,
                            pageNumber = usersResourceParameters.PageNumber + 1,
                            pageSize = usersResourceParameters.PageSize,
                            Email = usersResourceParameters.Email,
                            searchQuery = usersResourceParameters.SearchQuery,
                        });
                default:
                    return Url.Link("GetUsers",
                        new
                        {
                            orderBy = usersResourceParameters.OrderBy,
                            pageNumber = usersResourceParameters.PageNumber,
                            pageSize = usersResourceParameters.PageSize,
                            Email = usersResourceParameters.Email,
                            searchQuery = usersResourceParameters.SearchQuery,
                        });
            }
        }

    }
}
