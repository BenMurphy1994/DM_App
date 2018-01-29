namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaxTotal")]
    public partial class TaxTotal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        [StringLength(3)]
        public string RoundingAmount_CurrencyID { get; set; }

        public decimal? RoundingAmount_Value { get; set; }

        [StringLength(3)]
        public string TaxAmount_CurrencyID { get; set; }

        public decimal? TaxAmount_Value { get; set; }
    }
}
