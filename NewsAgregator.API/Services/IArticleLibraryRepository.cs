using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsAgregator.API.Entities;

namespace NewsAgregator.API.Services
{
    public interface IArticleLibraryRepository
    {
        IEnumerable<Article> GetAllArticles();
        IEnumerable<Article> GetArticles(Guid userId);
        Article GetArticle(Guid userId, Guid articleId);
        void AddArticle(Guid userId, Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(Article article);
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(string email, string searchQuery);
        User GetUser(Guid userId);
        IEnumerable<User> GetUsers(IEnumerable<Guid> userIds);
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        bool UserExists(Guid userId);
        bool Save();
    }
}
