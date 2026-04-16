// Axel,
//
//
// ### Evidence
//

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.CMS
{
    public class Page
    {
        [Key]
        public int IdPage { get; set; }

        [Required(ErrorMessage = "NavTitle is required")]
        [MaxLength(15)]
        [Display(Name = "NavTitle")]
        public required string NavTitle { get; set; }

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

        [MaxLength(20)]
        [Display(Name = "Template")]
        public string Template { get; set; } = "default";

        [Display(Name = "Subtitle")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Subtitle { get; set; }
    }
}

