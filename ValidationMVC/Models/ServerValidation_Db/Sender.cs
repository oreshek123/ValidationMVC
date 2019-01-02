using ValidationMVC.Filters;

namespace ValidationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Sender]
    public partial class Sender
    {
        public int SenderId { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Длина поля должна ровняться 12 символам")]
        public string BIN_IIN { get; set; }

        [Required]
        [StringLength(150)]
        public string ContactPerson { get; set; }

        [Required]
        public string SendersAddress { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DesirableDate { get; set; }

        public TimeSpan WhenPickUpShipment { get; set; }

        public int FormOfPaymentId { get; set; }

        public virtual FormOfPayment FormOfPayment { get; set; }
    }
}
