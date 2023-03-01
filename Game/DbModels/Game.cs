using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using TableAttribute = SQLite.TableAttribute;

namespace Game.DbModels
{
    [Table("game")]
    public class Games
    {
        [PrimaryKey, AutoIncrement]
        public int GameId { get; set; }

        [ForeignKey ("user")]
        public int UserId { get; set; }

        [MaxLength (5)]
        public string Selection { get; set; }

        [MaxLength (5)]
        public string Outcome { get; set; }

        public DateTime Timestamp { get; set;}

    }
}
