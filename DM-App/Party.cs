namespace DM_App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Party")]
    public partial class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Alias { get; set; }

        [StringLength(128)]
        public string EndpointID { get; set; }

        [StringLength(7)]
        public string LanguageCode { get; set; }

        [StringLength(260)]
        public string LogoReferenceID { get; set; }

        [StringLength(128)]
        public string PartyIdentification { get; set; }

        [StringLength(260)]
        public string WebsiteURI { get; set; }

        public long? Contact_Id { get; set; }

        public long? PartyLegalEntity_Id { get; set; }

        public long? PhysicalLocation_Id { get; set; }

        public long? PostalAddress_Id { get; set; }

        [StringLength(500)]
        public string Person_FamilyName { get; set; }

        [StringLength(500)]
        public string Person_FirstName { get; set; }

        public string Person_JobTitle { get; set; }

        [StringLength(500)]
        public string Person_MiddleName { get; set; }

        [StringLength(128)]
        public string Person_NameSuffix { get; set; }

        [StringLength(500)]
        public string Person_OrganizationDepartment { get; set; }

        public string Person_Title { get; set; }

        public Guid? Order_Id { get; set; }
    }
}
