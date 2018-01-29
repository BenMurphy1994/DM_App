namespace DM_App
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DM_Model : DbContext
    {
        public DM_Model()
            : base("name=DmModel")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AllowanceCharge> AllowanceCharges { get; set; }
        public virtual DbSet<CustomerParty> CustomerParties { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Mining> Minings { get; set; }
        public virtual DbSet<MonetaryTotal> MonetaryTotals { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderExtension> OrderExtensions { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<OrderLineExtension> OrderLineExtensions { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaxTotal> TaxTotals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowanceCharge>()
                .Property(e => e.MultiplierFactorNumeric)
                .HasPrecision(19, 5);

            modelBuilder.Entity<AllowanceCharge>()
                .Property(e => e.SequenceNumeric)
                .HasPrecision(19, 5);

            modelBuilder.Entity<AllowanceCharge>()
                .Property(e => e.Amount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<AllowanceCharge>()
                .Property(e => e.BaseAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.MaximumQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.MinimumQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.MaximumQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.MinimumQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.Item_PackQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.Item_PackSizeNumeric)
                .HasPrecision(19, 5);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.LineExtensionAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<LineItem>()
                .Property(e => e.TotalTaxAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<LineItem>()
                .HasMany(e => e.Deliveries)
                .WithOptional(e => e.LineItem)
                .HasForeignKey(e => e.LineItem_Id);

            modelBuilder.Entity<LineItem>()
                .HasOptional(e => e.OrderLine)
                .WithRequired(e => e.LineItem);

            modelBuilder.Entity<Mining>()
                .Property(e => e.Amount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Mining>()
                .Property(e => e.Quantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Mining>()
                .Property(e => e.LineExtensionAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Mining>()
                .Property(e => e.PayableAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Mining>()
                .Property(e => e.TaxInclusiveAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Mining>()
                .Property(e => e.BaseQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Mining>()
                .Property(e => e.PriceAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.AllowanceTotalAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.ChargeTotalAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.LineExtensionAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.PayableAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.PayableRoundingAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.PrepaidAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.TaxExclusiveAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<MonetaryTotal>()
                .Property(e => e.TaxInclusiveAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Order>()
                .HasOptional(e => e.OrderExtension)
                .WithRequired(e => e.Order);

            modelBuilder.Entity<OrderLineExtension>()
                .HasOptional(e => e.OrderLine)
                .WithRequired(e => e.OrderLineExtension);

            modelBuilder.Entity<Price>()
                .Property(e => e.BaseQuantity)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Price>()
                .Property(e => e.OrderableUnitFactorRate)
                .HasPrecision(19, 5);

            modelBuilder.Entity<Price>()
                .Property(e => e.PriceAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Price>()
                .HasMany(e => e.AllowanceCharges)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.Price_Id);

            modelBuilder.Entity<Price>()
                .HasMany(e => e.LineItems)
                .WithOptional(e => e.Price)
                .HasForeignKey(e => e.Price_Id);

            modelBuilder.Entity<TaxTotal>()
                .Property(e => e.RoundingAmount_Value)
                .HasPrecision(18, 6);

            modelBuilder.Entity<TaxTotal>()
                .Property(e => e.TaxAmount_Value)
                .HasPrecision(18, 6);
        }
    }
}
