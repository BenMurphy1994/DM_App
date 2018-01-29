namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AllowanceCharge")]
    public partial class AllowanceCharge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        public string AllowanceChargeReason { get; set; }

        [StringLength(128)]
        public string AllowanceChargeReasonCode { get; set; }

        public bool? ChargeIndicator { get; set; }

        [StringLength(128)]
        public string ID { get; set; }

        public decimal? MultiplierFactorNumeric { get; set; }

        public bool? PrepaidIndicator { get; set; }

        public decimal? SequenceNumeric { get; set; }

        public bool? ShippingIndicator { get; set; }

        public long? TaxCategory_Id { get; set; }

        public long? TaxTotal_Id { get; set; }

        [StringLength(3)]
        public string Amount_CurrencyID { get; set; }

        public decimal? Amount_Value { get; set; }

        [StringLength(3)]
        public string BaseAmount_CurrencyID { get; set; }

        public decimal? BaseAmount_Value { get; set; }

        public long? OrderLine_Id { get; set; }

        public Guid? Order_Id { get; set; }

        public long? Price_Id { get; set; }

        public virtual Price Price { get; set; }
    }
}
