using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgentHire.Data.Data.Projects
{
    public class Project
    {
        [Key]
        public int IdProject { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(80)]
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Budget is required")]
        [Display(Name = "Budget")]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [MaxLength(20)]
        [Display(Name = "Status")]
        public required string Status { get; set; }

        [Required(ErrorMessage = "PostedDate is required")]
        [Display(Name = "PostedDate")]
        public DateTime PostedDate { get; set; }

        [ForeignKey("ProjectCategory")]
        public int IdProjectCategory { get; set; }
        public ProjectCategory? ProjectCategory { get; set; }
    }
}