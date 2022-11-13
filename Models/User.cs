using SQLite;
namespace Game.Models
{
    [Table("user")]
    internal class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50), Unique]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
