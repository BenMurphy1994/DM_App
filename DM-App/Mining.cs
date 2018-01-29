namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mining")]
    public partial class Mining
    {
        [Key]
        public Guid Order_Id { get; set; }

        public DateTime? IssueDate { get; set; }

        [StringLength(3)]
        public string PricingCurrencyCode { get; set; }

        [StringLength(3)]
        public string TaxCurrencyCode { get; set; }

        [StringLength(128)]
        public string PartyIdentification { get; set; }

        public long? PostalAddress_Id { get; set; }

        [StringLength(500)]
        public string Product1 { get; set; }

        [StringLength(500)]
        public string Product2 { get; set; }

        [StringLength(500)]
        public string Product3 { get; set; }

        public string CityName { get; set; }

        public string Country { get; set; }

        public string CountrySubentity { get; set; }

        [StringLength(128)]
        public string PostalZone { get; set; }

        public string AllowanceChargeReason { get; set; }

        public decimal? Amount_Value { get; set; }

        public decimal? Quantity { get; set; }

        public string Item_AdditionalInformation { get; set; }

        [StringLength(128)]
        public string Item_Code { get; set; }

        [StringLength(500)]
        public string Item_Type { get; set; }

        public decimal? LineExtensionAmount_Value { get; set; }

        public decimal? PayableAmount_Value { get; set; }

        public decimal? TaxInclusiveAmount_Value { get; set; }

        public decimal? BaseQuantity { get; set; }

        public decimal? PriceAmount_Value { get; set; }

        public bool? IsSubscription { get; set; }

        public int? SubscriptionFrequency { get; set; }

        [StringLength(3)]
        public string DestinationCountryCode { get; set; }
    }
}
