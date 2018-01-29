namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderLineExtension
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrderLine_Id { get; set; }

        public bool? IsSubscription { get; set; }

        public int? SubscriptionFrequency { get; set; }

        public string RangeCode { get; set; }

        public string OriginatingListingPage { get; set; }

        public virtual OrderLine OrderLine { get; set; }
    }
}
