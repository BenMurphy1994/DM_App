namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Address")]
    public partial class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        public string CityName { get; set; }

        public string CountrySubentity { get; set; }

        public string Country { get; set; }

        [StringLength(3)]
        public string CountryCode { get; set; }

        [StringLength(128)]
        public string AddressTypeCode { get; set; }

        [StringLength(128)]
        public string PostalZone { get; set; }
    }
}
