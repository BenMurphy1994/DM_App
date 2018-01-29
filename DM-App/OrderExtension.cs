namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderExtension
    {
        [Key]
        public Guid Order_Id { get; set; }

        [StringLength(50)]
        public string NAVOrderId { get; set; }

        public DateTime? NavLastUpdate { get; set; }

        public bool? SentToNAV { get; set; }

        public bool? SyncFromNAV { get; set; }

        public string SentXML { get; set; }

        public string ResponseXML { get; set; }

        public string MediaCodes { get; set; }

        public byte? OrderState { get; set; }

        public virtual Order Order { get; set; }
    }
}
