using Game.DbModels;

namespace Game.Services
{
    public interface IUserService
    {
        public string StatusMessage { get; set; }
        public Task AddNewUser(string name, string password);
        public Task<List<User>> GetUser();
    }
}
