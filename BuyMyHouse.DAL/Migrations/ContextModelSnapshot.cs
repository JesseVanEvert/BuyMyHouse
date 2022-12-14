// <auto-generated />
using System;
using BuyMyHouse.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuyMyHouse.DAL.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BuyMyHouse.Model.Entities.Application", b =>
                {
                    b.Property<Guid>("ApplicationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AppliedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HouseID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationID");

                    b.HasIndex("HouseID");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("BuyMyHouse.Model.Entities.House", b =>
                {
                    b.Property<Guid>("HouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AskingPrice")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HouseID");

                    b.ToTable("House");
                });

            modelBuilder.Entity("BuyMyHouse.Model.Entities.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("YearlyIncomeInEuros")
                        .HasColumnType("float");

                    b.HasKey("PersonID");

                    b.HasIndex("ApplicationID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Person");
                });

            modelBuilder.Entity("BuyMyHouse.Model.Entities.Application", b =>
                {
                    b.HasOne("BuyMyHouse.Model.Entities.House", "House")
                        .WithMany("Applications")
                        .HasForeignKey("HouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("BuyMyHouse.Model.Entities.Person", b =>
                {
                    b.HasOne("BuyMyHouse.Model.Entities.Application", "Application")
                        .WithMany("Applicants")
                        .HasForeignKey("ApplicationID");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("BuyMyHouse.Model.Entities.Application", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("BuyMyHouse.Model.Entities.House", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
