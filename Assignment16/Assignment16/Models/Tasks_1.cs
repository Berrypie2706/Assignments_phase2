using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Assignment16.Models
{
    [Table("Tasks")]
    public class Task_1
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string Discription { get; set; }

        [Required]
        [StringLength(100)]
        public DateTime DueDate { get; set; }
    }
}
