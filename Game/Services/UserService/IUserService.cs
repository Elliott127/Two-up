﻿using Game.DbModels;

namespace Game.Services
{
    public interface IUserService
    {
        public string StatusMessage { get; set; }
        public Task AddNewUser(string name, string password);
        public Task<List<User>> GetListOfUsers();
        public Task <List<string>> GetUserInfo();
        public Task<bool> CheckUserCredentials(string username, string password);
        string HashPass(string pass);
        public Task DropTables();
        public Task<List<User>> GetUserInfoById();
        public Task UpdateUserScore(int score);
    }
}
