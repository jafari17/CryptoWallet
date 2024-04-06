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
        public virtual DbSet<UserTest> userTests { get; set; } = null!;
        public virtual DbSet<OptionPosition> optionPosition { get; set; } = null!;
        public virtual DbSet<OptionTransaction> optionTransaction { get; set; } = null!;



        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigUserTest(modelBuilder);
        }

        private void ConfigUserTest(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<UserTest>().HasKey(t => t.UserId);
            modelBuilder.Entity<UserTest>().Property(t => t.Name).HasMaxLength(250);
            modelBuilder.Entity<UserTest>().Property(t => t.Family).HasMaxLength(250);
            modelBuilder.Entity<UserTest>().Property(t => t.Email).HasMaxLength(350);
            #endregion

            #region optionPosition
            modelBuilder.Entity<OptionPosition>().HasKey(t => t.OptionPositionId);
            #endregion

            #region optionTransaction
            modelBuilder.Entity<OptionTransaction>().HasKey(t => t.TransactionLogId);
            #endregion
        }
        #endregion





    }
}
