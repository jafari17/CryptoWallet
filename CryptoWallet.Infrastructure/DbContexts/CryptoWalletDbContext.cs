using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoWallet.Domain.Entities;
using System.Reflection.Metadata;

namespace CryptoWallet.Infrastructure.DbContexts
{
    public class CryptoWalletDbContext : DbContext
    {
        public CryptoWalletDbContext()
        {
        }

        public CryptoWalletDbContext
            (DbContextOptions<CryptoWalletDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<OptionPositionHistory> optionPositionHistory { get; set; } = null!;
        public virtual DbSet<OptionTransaction> optionTransaction { get; set; } = null!;
        public virtual DbSet<OptionPosition> optionPosition { get; set; } = null!;
        public virtual DbSet<Asset> asset { get; set; } = null!;

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigUserTest(modelBuilder);
            ConfigOptionPosition(modelBuilder);
            ConfigAsset(modelBuilder);

        }

        private void ConfigUserTest(ModelBuilder modelBuilder)
        {
 

            #region optionPosition
            modelBuilder.Entity<OptionPositionHistory>().HasKey(t => t.OptionPositionId);
            #endregion

            #region optionTransaction
            modelBuilder.Entity<OptionTransaction>().HasKey(t => t.TransactionLogId);
            #endregion

 
        }
        #endregion

        private void ConfigOptionPosition(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OptionPosition>(entity =>
            {
                entity.ToTable("OptionPositions");

                entity.HasKey(e => e.OptionPositionId);

                entity.Property(e => e.OptionPositionId).HasColumnName("OptionPositionId");

                entity.HasMany(e => e.optionTransaction)
                     .WithOne(t => t.optionPosition)
                     .HasForeignKey(t => t.OptionPositionId)
                     .IsRequired();
            });
        }
        private void ConfigAsset(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().HasKey(t => t.AssetId);
        }

    }
}
