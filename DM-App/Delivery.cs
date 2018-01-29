namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delivery")]
    public partial class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LatestDeliveryDate { get; set; }

        public TimeSpan? LatestDeliveryTime { get; set; }

        public decimal? MaximumQuantity { get; set; }

        public decimal? MinimumQuantity { get; set; }

        public decimal? Quantity { get; set; }

        [StringLength(128)]
        public string TrackingID { get; set; }

        public long? AlternativeDeliveryLocation_Id { get; set; }

        public long? DeliveryAdress_Id { get; set; }

        public long? DeliveryLocation_Id { get; set; }

        public long? DeliveryParty_Id { get; set; }

        public long? Despatch_Id { get; set; }

        public Guid? Order_Id { get; set; }

        public long? LineItem_Id { get; set; }

        public string RequestedDeliveryPeriod_Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RequestedDeliveryPeriod_EndDate { get; set; }

        public TimeSpan? RequestedDeliveryPeriod_EndTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RequestedDeliveryPeriod_StartDate { get; set; }

        public TimeSpan? RequestedDeliveryPeriod_StartTime { get; set; }

        public virtual LineItem LineItem { get; set; }
    }
}
