using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using Easy.Core;
using Microsoft.Extensions.Configuration;
using System;

namespace Easy.Data
{
    public delegate void DbContextConfiguration(DbContextOptionsBuilder builder);

    public interface IRepository
    {
        DbSet<Candidate> Candidates { get; set; }
        DbSet<Phone> Phones { get; set; }
        DbSet<Skill> Skills { get; set; }
        void Delete<T>(T data) where T : class;
        void Save<T>(T data) where T : class;
    }

    class Repository : DbContext, IRepository
    {
        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Phone> Phones { get; set; }

        DbSet<Address> Address  { get; set; }
        DbSet<Account> Account { get; set; }

        DbContextConfiguration ConfigurationOptions { get; }

        public Repository(DbContextConfiguration configurationOptions)
        {
            ConfigurationOptions = configurationOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationOptions?.Invoke(optionsBuilder);            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(p => p.Email).HasColumnType("NVARCHAR(100)");
            modelBuilder.Entity<Account>()
                .HasKey(e => e.Email);
            modelBuilder.Entity<Candidate>()
                .HasOne(a => a.Address)
                .WithOne(a => a.Candidate);
            modelBuilder.Entity<Candidate>()
                .HasOne(a => a.Account)
                .WithOne(a => a.Candidate);
            base.OnModelCreating(modelBuilder.WithoutPluralizingTableNameConvention());
        }

        public void Delete<T>(T data) 
            where T : class
        {
            this.Set<T>().Remove(data);
            this.SaveChanges();
        }

        public void Save<T>(T data) where T : class
        {
            if (this.Entry(data).IsKeySet)
                this.Update(data);
            else
                this.Add(data);
            this.SaveChanges();
        }
    }
}
