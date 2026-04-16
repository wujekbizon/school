using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.CMS
{
    public class SiteConfig
    {
        [Key]
        public int IdSiteConfig { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Key")]
        public required string Key { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Value")]
        public required string Value { get; set; }

        [MaxLength(120)]
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
