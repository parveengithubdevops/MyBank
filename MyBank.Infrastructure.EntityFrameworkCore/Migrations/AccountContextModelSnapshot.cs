﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBank.Infrastructure.EntityFrameworkCore;

namespace MyBank.Infrastructure.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AccountContext))]
    partial class AccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("MyBank.Domain.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MyBank.Domain.Client", b =>
                {
                    b.OwnsOne("MyBank.Domain.Account", "Account", b1 =>
                        {
                            b1.Property<string>("Id")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("ClientId")
                                .HasColumnType("TEXT");

                            b1.HasKey("Id");

                            b1.HasIndex("ClientId")
                                .IsUnique();

                            b1.ToTable("Accounts");

                            b1.WithOwner("Client")
                                .HasForeignKey("ClientId");

                            b1.OwnsOne("MyBank.Domain.AccountBalance", "Balance", b2 =>
                                {
                                    b2.Property<string>("AccountId")
                                        .HasColumnType("TEXT");

                                    b2.Property<float>("Amount")
                                        .HasColumnType("REAL")
                                        .HasColumnName("Amount");

                                    b2.HasKey("AccountId");

                                    b2.ToTable("Accounts");

                                    b2.WithOwner()
                                        .HasForeignKey("AccountId");
                                });

                            b1.OwnsOne("MyBank.Domain.AccountNumber", "Number", b2 =>
                                {
                                    b2.Property<string>("AccountId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Number")
                                        .HasColumnType("TEXT")
                                        .HasColumnName("Number");

                                    b2.HasKey("AccountId");

                                    b2.ToTable("Accounts");

                                    b2.WithOwner()
                                        .HasForeignKey("AccountId");
                                });

                            b1.Navigation("Balance");

                            b1.Navigation("Client");

                            b1.Navigation("Number");
                        });

                    b.OwnsOne("MyBank.Domain.AccountOpeningRequest", "AccountOpeningRequest", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("ClientId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Name")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("RequestedAt")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Status")
                                .HasColumnType("INTEGER");

                            b1.HasKey("Id");

                            b1.HasIndex("ClientId")
                                .IsUnique();

                            b1.ToTable("AccountOpeningRequests");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Account");

                    b.Navigation("AccountOpeningRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
