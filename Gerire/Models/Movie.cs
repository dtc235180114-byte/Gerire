using System.ComponentModel.DataAnnotations;

namespace Gerire.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int price { get; set; }
        public int gerireId { get; set; }
        public gerire? gerire { get; set; }
    }
}
