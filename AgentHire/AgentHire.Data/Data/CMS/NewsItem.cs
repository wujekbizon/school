using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.CMS
{
    public class NewsItem
    {
        [Key]
        public int IdNewsItem { get; set; }

        [Required(ErrorMessage = "LinkTitle is required")]
        [MaxLength(15)]
        [Display(Name = "LinkTitle")]
        public required string LinkTitle { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(40)]
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Content { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public int Position { get; set; }
    }
}