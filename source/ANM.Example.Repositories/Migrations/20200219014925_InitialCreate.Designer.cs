﻿// <auto-generated />
using System;
using ANM.Example.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ANM.Example.Repositories.Migrations
{
    [DbContext(typeof(AnmDbContext))]
    [Migration("20200219014925_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ANM.Example.Domain.Stocks.Stock", b =>
                {
                    b.Property<string>("StockId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Ticker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("WalletId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("ANM.Example.Domain.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ANM.Example.Domain.Wallets.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<double>("AmountInvested")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("ANM.Example.Domain.Stocks.Stock", b =>
                {
                    b.HasOne("ANM.Example.Domain.Wallets.Wallet", "Wallet")
                        .WithMany("Stocks")
                        .HasForeignKey("WalletId");
                });

            modelBuilder.Entity("ANM.Example.Domain.Wallets.Wallet", b =>
                {
                    b.HasOne("ANM.Example.Domain.User.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("ANM.Example.Domain.Wallets.Wallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}