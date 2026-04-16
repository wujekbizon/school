//
// # Architecture Details
// * Utilizes System.ComponentModel.DataAnnotations and Schema
// * Implements required modifier for non-nullable strings
// * Defines read-only ICollection navigation property

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.Projects
{
    public class ProjectCategory
    {
        [Key]
        public int IdProjectCategory { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Description { get; set; }

        public ICollection<Project> Project { get; } = new List<Project>();
    }
}

