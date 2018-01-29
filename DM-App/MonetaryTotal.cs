namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonetaryTotal")]
    public partial class MonetaryTotal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        [StringLength(3)]
        public string AllowanceTotalAmount_CurrencyID { get; set; }

        public decimal? AllowanceTotalAmount_Value { get; set; }

        [StringLength(3)]
        public string ChargeTotalAmount_CurrencyID { get; set; }

        public decimal? ChargeTotalAmount_Value { get; set; }

        [StringLength(3)]
        public string LineExtensionAmount_CurrencyID { get; set; }

        public decimal? LineExtensionAmount_Value { get; set; }

        [StringLength(3)]
        public string PayableAmount_CurrencyID { get; set; }

        public decimal? PayableAmount_Value { get; set; }

        [StringLength(3)]
        public string PayableRoundingAmount_CurrencyID { get; set; }

        public decimal? PayableRoundingAmount_Value { get; set; }

        [StringLength(3)]
        public string PrepaidAmount_CurrencyID { get; set; }

        public decimal? PrepaidAmount_Value { get; set; }

        [StringLength(3)]
        public string TaxExclusiveAmount_CurrencyID { get; set; }

        public decimal? TaxExclusiveAmount_Value { get; set; }

        [StringLength(3)]
        public string TaxInclusiveAmount_CurrencyID { get; set; }

        public decimal? TaxInclusiveAmount_Value { get; set; }
    }
}
