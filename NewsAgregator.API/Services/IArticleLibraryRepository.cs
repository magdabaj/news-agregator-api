﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsAgregator.API.Entities;
using NewsAgregator.API.Helpers;
using NewsAgregator.API.ResourceParameters;

namespace NewsAgregator.API.Services
{
    public interface IArticleLibraryRepository
    {
        User Authenticate(string email, string password);
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
        PageList<User> GetUsers(UsersResourceParameters usersResourceParameters);
        bool Save();
    }
}
