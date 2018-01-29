namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineItem")]
    public partial class LineItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LineItem()
        {
            Deliveries = new HashSet<Delivery>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        [StringLength(128)]
        public string ID { get; set; }

        [StringLength(128)]
        public string LineStatusCode { get; set; }

        public decimal? MaximumQuantity { get; set; }

        public decimal? MinimumQuantity { get; set; }

        public string Note { get; set; }

        public string OrderID { get; set; }

        public bool? PartialDeliveryIndicator { get; set; }

        public decimal? Quantity { get; set; }

        public long? OrderedShipment_Id { get; set; }

        public long? ParentLine_Id { get; set; }

        public long? Price_Id { get; set; }

        public string Item_AdditionalInformation { get; set; }

        [StringLength(500)]
        public string Item_BrandName { get; set; }

        [StringLength(128)]
        public string Item_Code { get; set; }

        public string Item_Description { get; set; }

        public string Item_Keyword { get; set; }

        [StringLength(500)]
        public string Item_ModelName { get; set; }

        [StringLength(500)]
        public string Item_Name { get; set; }

        public decimal? Item_PackQuantity { get; set; }

        public decimal? Item_PackSizeNumeric { get; set; }

        [StringLength(128)]
        public string Item_Sku { get; set; }

        [StringLength(500)]
        public string Item_Type { get; set; }

        [StringLength(3)]
        public string LineExtensionAmount_CurrencyID { get; set; }

        public decimal? LineExtensionAmount_Value { get; set; }

        [StringLength(3)]
        public string TotalTaxAmount_CurrencyID { get; set; }

        public decimal? TotalTaxAmount_Value { get; set; }

        public long? LineItem_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Delivery> Deliveries { get; set; }

        public virtual Price Price { get; set; }

        public virtual OrderLine OrderLine { get; set; }
    }
}
