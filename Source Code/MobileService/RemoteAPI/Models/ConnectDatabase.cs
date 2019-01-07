using Data;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace RemoteAPI.Models
{
    public class ConnectDatabase : DbContext
    {
        
        public ConnectDatabase()
            : base("conn")
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}