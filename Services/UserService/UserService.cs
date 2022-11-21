using SQLite;
using Game.DbModels;
using System.Security.Cryptography;

namespace Game.Services
{
    public class UserService : IUserService
    {

        private SQLiteAsyncConnection conn;
        private readonly string dbPath;
        private int id;

        public string StatusMessage { get; set; }

        public UserService()
        {
            dbPath = FileAccessHelper.GetLocalFilePath(Constants.DbFileName);
        }

        public async Task DropTables()
        {
            await Init();
            await conn.DropTableAsync<User>();
            await conn.DropTableAsync<Games>();
        }

        public string HashPass(string pass)
        {
            string salt = "%$3!/>";
            if (string.IsNullOrEmpty(pass))
            {
                return string.Empty;
            }
            using SHA256Managed sha = new();

            // Convert the string to a byte array first, to be processed
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(pass + salt);
            byte[] hashBytes = sha.ComputeHash(textBytes);

            // Convert back to a string, removing the '-' that BitConverter adds
            string hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", string.Empty);

            return hash;
        }

        public async Task AddNewUser(string name, string password)
        {
            int result;
            try
            {
                await Init();
                if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(password))
                    throw new Exception("Valid name or password required");


                result = await conn.InsertAsync(new User { Username = name, Password = HashPass(password) });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);

            }
        }

        public async Task<List<User>> GetListOfUsers()
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

        public async Task<List<string>> GetUserInfo()
        {
            List<User> users;
            List<string> userInfo = new();
            users = await GetUserInfoById();

            userInfo.Add(users[0].Username);
            userInfo.Add(users[0].Score.ToString());

            return userInfo;
        }

        public async Task<bool> CheckUserCredentials(string username, string password)
        {
            List<User> users = await GetListOfUsers();
            foreach (User user in users)
            {
                if (username == user.Username && user.Password == HashPass(password))
                {
                    id = user.UserId;
                    return true;
                }
            }
            return false;
        }

        public async Task<List<User>> GetUserInfoById()
        {
            return await conn.QueryAsync<User>($"SELECT * FROM User WHERE UserId = {this.id}");
        }

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<User>();
            await conn.CreateTableAsync<Games>();
        }

    }
}
