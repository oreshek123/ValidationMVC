using ValidationMVC.Filters;

namespace ValidationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Track]
    public partial class DescriptionOfGood
    {
        [Key]
        public int DescriptionOfGoodsId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int DepartureTypeId { get; set; }

        public int TariffsViewId { get; set; }

        public decimal Weight { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual DepartureType DepartureType { get; set; }

        public virtual TariffsView TariffsView { get; set; }
    }
}
