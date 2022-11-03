using GlennsHotrods2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlennsHotrods2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceWriter> ServiceWriters { get; set; }
        public DbSet<WorkOrder> workOrders { get; set; }    //WorkOrders should have been uppercase

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceWriter>().HasData(
                new ServiceWriter { ServiceWriterId = 1, Name= "Glenn" },
                new ServiceWriter { ServiceWriterId = 2, Name = "Jennifer"},
                new ServiceWriter { ServiceWriterId = 3, Name = "Barney"}
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Val Kilmer",
                    Contact = "Val",
                    Phone1 = "402-555-5555",
                    CreateDate = Convert.ToDateTime("10/12/2022"),
                    Email= "vk@scc.com",
                    ServiceWriterId = 1
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Tom Cruse",
                    Contact = "Tom",
                    Phone1 = "402-555-6666",
                    CreateDate = Convert.ToDateTime("10/12/2022"),
                    Email = "tc@scc.com",
                    ServiceWriterId = 3
                },
                new Customer
                {
                    CustomerId = 3,
                    CustomerName = "Jack Benny",
                    Contact = "Jack",
                    Phone1 = "402-555-7777",
                    CreateDate = Convert.ToDateTime("10/12/2022"),
                    Email = "jb@scc.com",
                    ServiceWriterId = 2
                }
                ); 
        }

        public DbSet<GlennsHotrods2.Models.WorkOrderViewModel> WorkOrderViewModel { get; set; }
    }
}
