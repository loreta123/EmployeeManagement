using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
    }
}
