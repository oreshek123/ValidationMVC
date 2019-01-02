using ValidationMVC.Filters;

namespace ValidationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [FeedBack]
    public partial class Feedback
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        public int MessageThemeId { get; set; }

        [Required]
        [MinLength(10)]
        public string Question { get; set; }

        public virtual MessageTheme MessageTheme { get; set; }
    }
}
