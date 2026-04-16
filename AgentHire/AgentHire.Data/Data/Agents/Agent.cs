using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.Agents
{
    public class Agent
    {
        [Key]
        public int IdAgent { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [MaxLength(60)]
        [Display(Name = "FullName")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        [Display(Name = "Bio")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Bio { get; set; }

        [Required(ErrorMessage = "HourlyRate is required")]
        [Display(Name = "HourlyRate")]
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }

        [Required(ErrorMessage = "AvatarUrl is required")]
        [Display(Name = "AvatarUrl")]
        public required string AvatarUrl { get; set; }

        [Display(Name = "IsHighlighted")]
        public bool IsHighlighted { get; set; } = false;

        [ForeignKey("Specialization")]
        public int IdSpecialization { get; set; }
        public Specialization? Specialization { get; set; }

        public ICollection<PortfolioItem> PortfolioItem { get; } = new List<PortfolioItem>();
    }
}