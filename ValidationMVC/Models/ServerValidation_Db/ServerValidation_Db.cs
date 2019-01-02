namespace ValidationMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ServerValidation_Db : DbContext
    {
        public ServerValidation_Db()
            : base("name=ServerValidation_Db")
        {
        }

        public virtual DbSet<CallingCourier> CallingCouriers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DepartureType> DepartureTypes { get; set; }
        public virtual DbSet<DescriptionOfGood> DescriptionOfGoods { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FormOfPayment> FormOfPayments { get; set; }
        public virtual DbSet<MessageTheme> MessageThemes { get; set; }
        public virtual DbSet<Sender> Senders { get; set; }
        public virtual DbSet<TariffsView> TariffsViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallingCourier>()
                .Property(e => e.BIN_IIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CallingCourier>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<City>()
                .HasMany(e => e.CallingCouriers)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.DescriptionOfGoods)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.CallingCouriers)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.DescriptionOfGoods)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DepartureType>()
                .HasMany(e => e.CallingCouriers)
                .WithRequired(e => e.DepartureType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DepartureType>()
                .HasMany(e => e.DescriptionOfGoods)
                .WithRequired(e => e.DepartureType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DescriptionOfGood>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<FormOfPayment>()
                .HasMany(e => e.CallingCouriers)
                .WithRequired(e => e.FormOfPayment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormOfPayment>()
                .HasMany(e => e.Senders)
                .WithRequired(e => e.FormOfPayment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MessageTheme>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.MessageTheme)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sender>()
                .Property(e => e.BIN_IIN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TariffsView>()
                .HasMany(e => e.CallingCouriers)
                .WithRequired(e => e.TariffsView)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TariffsView>()
                .HasMany(e => e.DescriptionOfGoods)
                .WithRequired(e => e.TariffsView)
                .WillCascadeOnDelete(false);
        }
    }
}
