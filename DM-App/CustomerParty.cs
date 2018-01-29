namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerParty")]
    public partial class CustomerParty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        [StringLength(128)]
        public string CustomerAssignedAccountID { get; set; }

        [StringLength(128)]
        public string SupplierAssignedAccountID { get; set; }

        public long? AccountingContact_Id { get; set; }

        public long? BuyerContact_Id { get; set; }

        public long? DeliveryContact_Id { get; set; }

        public long? Party_Id { get; set; }
    }
}
