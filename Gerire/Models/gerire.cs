using System.ComponentModel.DataAnnotations;

namespace Gerire.Models
{
    public class gerire
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
