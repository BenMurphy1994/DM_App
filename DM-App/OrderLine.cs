namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderLine")]
    public partial class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        public string Note { get; set; }

        public Guid? Order_Id { get; set; }

        public virtual LineItem LineItem { get; set; }

        public virtual OrderLineExtension OrderLineExtension { get; set; }
    }
}
