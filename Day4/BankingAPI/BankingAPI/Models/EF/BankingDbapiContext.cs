using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Models.EF;

public partial class BankingDbapiContext : DbContext
{
    public BankingDbapiContext()
    {
    }

    public BankingDbapiContext(DbContextOptions<BankingDbapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountInfo> AccountInfos { get; set; }

    public virtual DbSet<BranchInfo> BranchInfos { get; set; }

    public virtual DbSet<TransactionInfo> TransactionInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=bankingDBAPI;integrated security=true;trust server certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountInfo>(entity =>
        {
            entity.HasKey(e => e.AccountNo).HasName("PK__accountI__F267E82540E13F5C");

            entity.ToTable("accountInfo");

            entity.Property(e => e.AccountNo)
                .ValueGeneratedNever()
                .HasColumnName("accountNo");
            entity.Property(e => e.AccountBalnce)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("accountBalnce");
            entity.Property(e => e.AccountBranch).HasColumnName("accountBranch");
            entity.Property(e => e.AccountIsActive).HasColumnName("accountIsActive");
            entity.Property(e => e.AccountName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("accountName");

            entity.HasOne(d => d.AccountBranchNavigation).WithMany(p => p.AccountInfos)
                .HasForeignKey(d => d.AccountBranch)
                .HasConstraintName("FK__accountIn__accou__25869641");
        });

        modelBuilder.Entity<BranchInfo>(entity =>
        {
            entity.HasKey(e => e.BranchNo).HasName("PK__branchIn__751EC4A0A3CEBA38");

            entity.ToTable("branchInfo");

            entity.Property(e => e.BranchNo)
                .ValueGeneratedNever()
                .HasColumnName("branchNo");
            entity.Property(e => e.BranchCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("branchCity");
            entity.Property(e => e.BranchName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("branchName");
        });

        modelBuilder.Entity<TransactionInfo>(entity =>
        {
            entity.HasKey(e => e.TransactionNo).HasName("PK__transact__9B5707803E0BEC6B");

            entity.ToTable("transactionInfo");

            entity.Property(e => e.TransactionNo)
                .ValueGeneratedNever()
                .HasColumnName("transactionNo");
            entity.Property(e => e.TransactionAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("transactionAmount");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("transactionDate");
            entity.Property(e => e.TransactionFromAcc).HasColumnName("transactionFromAcc");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("transactionStatus");
            entity.Property(e => e.TransactionToAcc).HasColumnName("transactionToAcc");

            entity.HasOne(d => d.TransactionFromAccNavigation).WithMany(p => p.TransactionInfoTransactionFromAccNavigations)
                .HasForeignKey(d => d.TransactionFromAcc)
                .HasConstraintName("FK__transacti__trans__286302EC");

            entity.HasOne(d => d.TransactionToAccNavigation).WithMany(p => p.TransactionInfoTransactionToAccNavigations)
                .HasForeignKey(d => d.TransactionToAcc)
                .HasConstraintName("FK__transacti__trans__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
