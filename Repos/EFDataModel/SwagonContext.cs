using Microsoft.EntityFrameworkCore;

namespace Swagon.DataBase.DataModel
{
    public partial class SwagonContext : DbContext
    {
        public SwagonContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=swagon;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookingCreatorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookingFare)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FromCityId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RideOfferId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToCityId)
                    .IsRequired()
                    .HasColumnName("ToCityID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Latitute)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RideOffer>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromCityId)
                    .IsRequired()
                    .HasColumnName("FromCityID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JourneyDate)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OfferCreatorId)
                    .IsRequired()
                    .HasColumnName("OfferCreatorID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToCityId)
                    .IsRequired()
                    .HasColumnName("ToCityID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stops>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityIdofStop)
                    .IsRequired()
                    .HasColumnName("CityIDofStop")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfferId)
                    .IsRequired()
                    .HasColumnName("OfferID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cityofliving)
                    .HasColumnName("cityofliving")
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .IsUnicode(false);

                entity.Property(e => e.SecretInfo)
                    .HasColumnName("secretInfo")
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
