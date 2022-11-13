using SQLite;
using Game.Models;

namespace Game.Repo
{
    public class UserRepo
    {
        SQLiteAsyncConnection conn;
        string dbPath;

        public string StatusMessage { get; set; }

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(dbPath);
            await conn.CreateTableAsync<User>();
        }

        public UserRepo(string dbPath)
        {
            this.dbPath = dbPath;
        }
        public async Task AddNewUser(string name)
        {
            int result = 0;
            try
            {
                await Init();

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result =  await conn.InsertAsync(new User { Username = name});

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}",name, ex.Message);

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
    }
}
