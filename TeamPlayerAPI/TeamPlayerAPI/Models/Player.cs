using System.ComponentModel.DataAnnotations;

namespace TeamPlayerAPI.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
    }
}
