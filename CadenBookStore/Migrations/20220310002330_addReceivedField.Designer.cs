﻿// <auto-generated />
using System;
using CadenBookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadenBookStore.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20220310002330_addReceivedField")]
    partial class addReceivedField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("CadenBookStore.Models.BasketLineItem", b =>
                {
                    b.Property<int>("LineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookCartCartId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("LineID");

                    b.HasIndex("BookCartCartId");

                    b.HasIndex("BookId");

                    b.ToTable("BasketLineItem");
                });

            modelBuilder.Entity("CadenBookStore.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CadenBookStore.Models.BookCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("TEXT");

                    b.Property<bool>("BookReceived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Zip")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartId");

                    b.ToTable("bookcarts");
                });

            modelBuilder.Entity("CadenBookStore.Models.BasketLineItem", b =>
                {
                    b.HasOne("CadenBookStore.Models.BookCart", null)
                        .WithMany("Lines")
                        .HasForeignKey("BookCartCartId");

                    b.HasOne("CadenBookStore.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");
                });
#pragma warning restore 612, 618
        }
    }
}
