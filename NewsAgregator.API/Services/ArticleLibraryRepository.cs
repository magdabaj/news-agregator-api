using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CourseLibrary.API;
using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NewsAgregator.API.Entities;
using NewsAgregator.API.Helpers;

namespace NewsAgregator.API.Services
{
    public class ArticleLibraryRepository : IArticleLibraryRepository, IDisposable
    {
        private readonly CourseLibraryContext _context;
        private readonly IOptions<JwtAuthentication> _jwtAuthentication;

        public ArticleLibraryRepository(CourseLibraryContext context, IOptions<JwtAuthentication> jwtAuthentication)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //_appSettings = appSettings.Value;
            _jwtAuthentication = jwtAuthentication ??
                throw new ArgumentNullException(nameof(jwtAuthentication));
        }
        public void AddArticle(Guid userId, Article article)
        {
            if(userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if(article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            article.UserId = userId;
            _context.Articles.Add(article);
        }

        public void AddUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.Id = Guid.NewGuid();

            foreach(var article in user.Articles)
            {
                article.Id = Guid.NewGuid();
            }

            _context.Users.Add(user);
        }

        public User Authenticate(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var token = new JwtSecurityToken(
                issuer: _jwtAuthentication.Value.ValidIssuer,
                audience: _jwtAuthentication.Value.ValidAudience,
                claims: new[]
                {
                // You can add more claims if you want
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                },
                expires: DateTime.UtcNow.AddDays(30),
                notBefore: DateTime.UtcNow,
                signingCredentials: _jwtAuthentication.Value.SigningCredentials);

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return user;

        }

        public void DeleteArticle(Article article)
        {
            _context.Articles.Remove(article);
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _context.Articles.ToList<Article>();
        }

        public Article GetArticle(Guid userId, Guid articleId)
        {
            if(userId == Guid.Empty){
                throw new ArgumentNullException(nameof(userId));
            }

            if(articleId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(articleId));
            }

            return _context.Articles
                .Where(A => A.UserId == userId && A.Id == articleId).FirstOrDefault();
        }

        public IEnumerable<Article> GetArticles(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Articles
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.Title).ToList();
        }

        public User GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }

        public IEnumerable<User> GetUsers(string email, string searchQuery)
        {
            if(string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(searchQuery))
            {
                return GetUsers();
            }

            var collection = _context.Users as IQueryable<User>;

            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim();
                collection = collection.Where(u => u.Email == email);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(u => u.FirstName.Contains(searchQuery)
                || u.LastName.Contains(searchQuery));
            }

            return collection.ToList();
        }

        public IEnumerable<User> GetUsers(IEnumerable<Guid> userIds)
        {
            if (userIds == null)
            {
                throw new ArgumentNullException(nameof(userIds));
            }

            return _context.Users.Where(u => userIds.Contains(u.Id))
                .OrderBy(u => u.FirstName)
                .OrderBy(u => u.LastName)
                .ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //dispose resources when needed
            }
        }

        public void UpdateArticle(Article article)
        {
            //
        }

        public void UpdateUser(User user)
        {
            //
        }

        public bool UserExists(Guid userId)
        {
            if(userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.Any(u => u.Id == userId);
        }

        
    }
}
