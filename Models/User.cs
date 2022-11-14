using SQLite;
using System.Security.Cryptography;

namespace Game.Models
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [MaxLength(50), Unique]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { private get; set; }
    }
}
