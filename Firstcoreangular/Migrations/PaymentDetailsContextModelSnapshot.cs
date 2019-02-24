﻿// <auto-generated />
using Firstcoreangular.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firstcoreangular.Migrations
{
    [DbContext(typeof(PaymentDetailsContext))]
    partial class PaymentDetailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Firstcoreangular.Model.PaymentDetails", b =>
                {
                    b.Property<int>("PMId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("CardOwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("PMId");

                    b.ToTable("PaymentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
