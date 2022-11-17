using SQLite;
using System.Security.Cryptography;

namespace Game.DbModels
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [MaxLength(50), Unique]
        public string Username { get; set; }

        [MaxLength(50)]
        public int Score { get; set; }

        [MaxLength(50)]
        public Rfc2898DeriveBytes Password { get; set; }
    }
}
