using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = SQLite.TableAttribute;

namespace Game.Models
{
    [Table("game")]
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int GameId { get; set; }

        [ForeignKey ("user")]
        public int UserId { get; set; }
        [MaxLength(50)]
        public int Score { get; set; }
        [MaxLength (5)]
        public string Selection { get; set; }
        [MaxLength (5)]
        public string Outcome { get; set; }
        
        public DateTime Timestamp { get; set;}

    }
}
