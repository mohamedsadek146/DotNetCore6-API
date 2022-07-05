using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetCore6.Models.HR;
using DotNetCore6.Models.User;
using DotNetCore6.Models.ToDo;
using DotNetCore6.Models;

namespace DotNetCore6.Data
{
    public partial class Entities : DbContext
    {
        public Entities()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public Entities(DbContextOptions<Entities> options)
           : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        #region users
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPassword> UserPasswords { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<TokenLog> TokenLogs { get; set; }
        public virtual DbSet<TokenAction> TokenActions { get; set; }
        public virtual DbSet<PageAction> PageActions { get; set; }
        public virtual DbSet<RoleAction> RoleActions { get; set; }
        
        #endregion
        #region HR
        public virtual DbSet<Job> Jobs { get; set; }
        #endregion
        public virtual DbSet<Student> Students { get; set; }

        #region ToDo
        public virtual DbSet<Models.ToDo.Task> Tasks { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //string cs = ConfigurationManager.ConnectionStrings["Default"]..ConnectionString;
            if (!optionsBuilder.IsConfigured)
            {
                //string cs = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DotNetCore6;User ID=sa;Password=roboost");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            //modelBuilder..Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder
            //    .Entity<TripPerformanceDetail>(eb =>
            //    {
            //        eb.HasNoKey();
            //        eb.ToView("TripPerformanceDetail", "Trip");
            //        eb.Property(v => new { v.BranchID, v.Date, v.DeliverymanID }).HasColumnName("ID");
            //    });
            //modelBuilder.Property(x => x.EntityCreated).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
            });


            modelBuilder.Entity<PageAction>()
             .HasKey(o => new { o.PageID, o.ActionID });

            modelBuilder.Entity<RoleAction>()
             .HasKey(o => new { o.RoleID, o.PageID, o.ActionID });
        }
        }
    }
