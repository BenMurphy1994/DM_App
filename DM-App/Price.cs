namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Price")]
    public partial class Price
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Price()
        {
            AllowanceCharges = new HashSet<AllowanceCharge>();
            LineItems = new HashSet<LineItem>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        public decimal? BaseQuantity { get; set; }

        public decimal? OrderableUnitFactorRate { get; set; }

        public string PriceChangeReason { get; set; }

        public string PriceType { get; set; }

        [StringLength(128)]
        public string PriceTypeCode { get; set; }

        [StringLength(3)]
        public string PriceAmount_CurrencyID { get; set; }

        public decimal? PriceAmount_Value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AllowanceCharge> AllowanceCharges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
