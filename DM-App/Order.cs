namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public Guid ID { get; set; }

        [StringLength(3)]
        public string DestinationCountryCode { get; set; }

        public DateTime IssueDate { get; set; }

        public string Note { get; set; }

        [Required]
        [StringLength(128)]
        public string OrderId { get; set; }

        [StringLength(3)]
        public string PricingCurrencyCode { get; set; }

        [Required]
        [StringLength(128)]
        public string ShopContext { get; set; }

        [StringLength(3)]
        public string TaxCurrencyCode { get; set; }

        public long? AccountingCustomerParty_Id { get; set; }

        public long? AnticipatedMonetaryTotal_Id { get; set; }

        public long? BuyerCustomerParty_Id { get; set; }

        public long? SellerSupplierParty_Id { get; set; }

        public long? State_Id { get; set; }

        public long? TaxTotal_Id { get; set; }

        public virtual OrderExtension OrderExtension { get; set; }
    }
}
