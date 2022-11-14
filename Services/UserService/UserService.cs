using SQLite;
using Game.Models;
using System.Security.Cryptography;

namespace Game.Services
{
    public class UserService : IUserService
    {

        private SQLiteAsyncConnection conn;
        private readonly string dbPath;

        public string StatusMessage { get; set; }

        public UserService()
        {
            dbPath = FileAccessHelper.GetLocalFilePath(Constants.DbFileName);
        }

        public async Task AddNewUser(string name, string password)
        {
            int result;
            try
            {
                await Init();
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(password))
                    throw new Exception("Valid name or password required");

                Rfc2898DeriveBytes pass = new(password, 2);

                result = await conn.InsertAsync(new User { Username = name, Password = pass.ToString() });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);

            }
        }

        public async Task CheckPassword(string Username, string password)
        {
            int result = 0;
            try
            {
                await Init();
                result = 1;
                await conn.Table<User>().ToListAsync();
            }
            catch(Exception ex)
            {
                StatusMessage = "Woah buddy slow down " + ex.Message + result;
            }
        }

        public async Task<List<User>> GetUser()
        {
            try
            {
                await Init();
                return await conn.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);

            }
            return new List<User>();
        }

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<User>();
        }
    }
}
