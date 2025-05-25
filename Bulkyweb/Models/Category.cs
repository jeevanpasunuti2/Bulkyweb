using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulkyweb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        [MaxLength(10)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(1, 100, ErrorMessage ="You Must enter Valid range of data between 1-100")]
        public int DisplayOrder { get; set; }

    }
}
