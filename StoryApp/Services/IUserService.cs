﻿using StoryApp.Models;

namespace StoryApp.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> AddAndUpdateUser(User userObj);
    }
}
