using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment18.Models
{
    [Table("Movies")]
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public DateTime Releasedate { get; set; }
    }
}
