using CRMApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMApp.Infrastucture.Data
{
    public class CRMAppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CRMAppDbContext(DbContextOptions<CRMAppDbContext> options) : base(options) { }
    }
}