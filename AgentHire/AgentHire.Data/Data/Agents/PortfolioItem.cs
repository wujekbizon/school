using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.Agents
{
    public class PortfolioItem
    {
        [Key]
        public int IdPortfolioItem { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(80)]
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Description { get; set; }

        [Display(Name = "ProjectUrl")]
        public string ProjectUrl { get; set; } = string.Empty;

        [ForeignKey("Agent")]
        public int IdAgent { get; set; }
        public Agent? Agent { get; set; }
    }
}