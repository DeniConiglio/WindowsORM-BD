using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsAppPubs.Models
{
    public partial class PubsContext : DbContext
    {
        public PubsContext()
            : base("name=PubsContext1")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<PubInfo> PubInfos { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<TitleAuthor> TitleAuthors { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Roysched> Royscheds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.au_id)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.au_lname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.au_fname)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.TitleAuthors)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.emp_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.minit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.lname)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.job_desc)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PubInfo>()
                .Property(e => e.PubId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PubInfo>()
                .Property(e => e.PrInfo)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.pub_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.pub_name)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Publisher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .HasOptional(e => e.PubInfo)
                .WithRequired(e => e.Publisher);

            modelBuilder.Entity<Sale>()
                .Property(e => e.stor_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.OrdNum)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Payterms)
                .IsUnicode(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.TitleId)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.stor_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.stor_name)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.stor_address)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.State)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Zip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TitleAuthor>()
                .Property(e => e.AuId)
                .IsUnicode(false);

            modelBuilder.Entity<TitleAuthor>()
                .Property(e => e.TitleId)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.TitleId)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Title1)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Type)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.PubId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Title>()
                .Property(e => e.Advance)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Title>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.TitleAuthors)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .HasOptional(e => e.Roysched)
                .WithRequired(e => e.Title);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Discounttype)
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Storid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Discount>()
                .Property(e => e.Discount1)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Roysched>()
                .Property(e => e.TitleId)
                .IsUnicode(false);
        }
    }
}
