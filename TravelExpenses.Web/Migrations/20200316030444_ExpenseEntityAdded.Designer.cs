﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelExpenses.Web.Data;

namespace TravelExpenses.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200316030444_ExpenseEntityAdded")]
    partial class ExpenseEntityAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelExpenses.Web.Data.Entities.ExpenseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ReceiptPath");

                    b.Property<int?>("TravelId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("TravelExpenses.Web.Data.Entities.TravelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("TravelExpenses.Web.Data.Entities.ExpenseEntity", b =>
                {
                    b.HasOne("TravelExpenses.Web.Data.Entities.TravelEntity", "Travel")
                        .WithMany("Expenses")
                        .HasForeignKey("TravelId");
                });
#pragma warning restore 612, 618
        }
    }
}
