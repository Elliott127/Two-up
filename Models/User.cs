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
        public Rfc2898DeriveBytes Password { private get; set; }
    }
}
