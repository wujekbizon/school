
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.Projects
{
    public class Inquiry
    {
        [Key]
        public int IdInquiry { get; set; }

        [Required(ErrorMessage = "SenderName is required")]
        [MaxLength(60)]
        [Display(Name = "SenderName")]
        public required string SenderName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100)]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [Display(Name = "Message")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Message { get; set; }

        [Required(ErrorMessage = "SubmittedAt is required")]
        [Display(Name = "SubmittedAt")]
        public DateTime SubmittedAt { get; set; }
    }
}

