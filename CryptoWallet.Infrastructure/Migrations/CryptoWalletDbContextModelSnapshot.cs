﻿// <auto-generated />
using System;
using CryptoWallet.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoWallet.Infrastructure.Migrations
{
    [DbContext(typeof(CryptoWalletDbContext))]
    partial class CryptoWalletDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("CryptoWallet.Domain.Entities.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Value")
                        .HasColumnType("TEXT");

                    b.Property<string>("currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("equity")
                        .HasColumnType("TEXT");

                    b.HasKey("AssetId");

                    b.ToTable("asset");
                });

            modelBuilder.Entity("CryptoWallet.Domain.Entities.OptionPosition", b =>
                {
                    b.Property<int>("OptionPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("OptionPositionId");

                    b.Property<bool?>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("MarkPrice")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("ResponseOut")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalProfitLoss")
                        .HasColumnType("REAL");

                    b.Property<double>("average_price")
                        .HasColumnType("REAL");

                    b.Property<double>("delta")
                        .HasColumnType("REAL");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<double>("size")
                        .HasColumnType("REAL");

                    b.HasKey("OptionPositionId");

                    b.ToTable("OptionPositions", (string)null);
                });

            modelBuilder.Entity("CryptoWallet.Domain.Entities.OptionPositionHistory", b =>
                {
                    b.Property<int>("OptionPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("MarkPrice")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("ResponseOut")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalProfitLoss")
                        .HasColumnType("REAL");

                    b.Property<double>("average_price")
                        .HasColumnType("REAL");

                    b.Property<double>("delta")
                        .HasColumnType("REAL");

                    b.Property<double>("size")
                        .HasColumnType("REAL");

                    b.HasKey("OptionPositionId");

                    b.ToTable("optionPositionHistory");
                });

            modelBuilder.Entity("CryptoWallet.Domain.Entities.OptionTransaction", b =>
                {
                    b.Property<long>("TransactionLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<double>("Cashflow")
                        .HasColumnType("REAL");

                    b.Property<double>("Change")
                        .HasColumnType("REAL");

                    b.Property<double>("Commission")
                        .HasColumnType("REAL");

                    b.Property<double>("Contracts")
                        .HasColumnType("REAL");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Equity")
                        .HasColumnType("REAL");

                    b.Property<double>("FeeBalance")
                        .HasColumnType("REAL");

                    b.Property<int>("IdJson")
                        .HasColumnType("INTEGER");

                    b.Property<double>("IndexPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("InterestPl")
                        .HasColumnType("REAL");

                    b.Property<double>("MarkPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("OptionPositionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Position")
                        .HasColumnType("REAL");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("PriceCurrency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfitAsCashflow")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Side")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Timestamp")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TradeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("UserSeq")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionLogId");

                    b.HasIndex("OptionPositionId");

                    b.ToTable("optionTransaction");
                });

            modelBuilder.Entity("CryptoWallet.Domain.Entities.OptionTransaction", b =>
                {
                    b.HasOne("CryptoWallet.Domain.Entities.OptionPosition", "optionPosition")
                        .WithMany("optionTransaction")
                        .HasForeignKey("OptionPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("optionPosition");
                });

            modelBuilder.Entity("CryptoWallet.Domain.Entities.OptionPosition", b =>
                {
                    b.Navigation("optionTransaction");
                });
#pragma warning restore 612, 618
        }
    }
}
