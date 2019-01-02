namespace ValidationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CallingCourier
    {
        public int CallingCourierId { get; set; }

        [Required]
        [StringLength(12)]
        public string BIN_IIN { get; set; }

        [Required]
        [StringLength(150)]
        public string ContactPerson { get; set; }

        [Required]
        public string SendersAddress { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        public DateTime DesirableDate { get; set; }

        public TimeSpan WhenPickUpShipment { get; set; }

        public int FormOfPaymentId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int DepartureTypeId { get; set; }

        public int TariffsViewId { get; set; }

        public decimal Weight { get; set; }

        public virtual FormOfPayment FormOfPayment { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual DepartureType DepartureType { get; set; }

        public virtual TariffsView TariffsView { get; set; }
    }
}
