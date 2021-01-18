﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    partial class PizzaBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("APizzaModelTopping", b =>
                {
                    b.Property<long>("PizzasEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("ToppingsEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("PizzasEntityID", "ToppingsEntityID");

                    b.HasIndex("ToppingsEntityID");

                    b.ToTable("APizzaModelTopping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaModel", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Crust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderEntityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("SizeEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("OrderEntityID");

                    b.HasIndex("SizeEntityID");

                    b.ToTable("APizzaModel");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateModifier")
                        .HasColumnType("datetime2");

                    b.Property<long?>("StoreEntityID")
                        .HasColumnType("bigint");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<long?>("UserEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("StoreEntityID");

                    b.HasIndex("UserEntityID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "one"
                        },
                        new
                        {
                            EntityID = 2L,
                            Name = "two"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("SelectedStoreEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.HasIndex("SelectedStoreEntityID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APizzaModelTopping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizzaModel", null)
                        .WithMany()
                        .HasForeignKey("PizzasEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaModel", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderEntityID");

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany("Pizzas")
                        .HasForeignKey("SizeEntityID");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityID");

                    b.HasOne("PizzaBox.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserEntityID");

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Store", "SelectedStore")
                        .WithMany()
                        .HasForeignKey("SelectedStoreEntityID");

                    b.Navigation("SelectedStore");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Store", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
