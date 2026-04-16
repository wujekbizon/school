using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.Agents
{
    public class Specialization
    {
        [Key]
        public int IdSpecialization { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Description { get; set; }

        public ICollection<Agent> Agent { get; } = new List<Agent>();
    }
}