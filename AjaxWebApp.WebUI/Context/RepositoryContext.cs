using AjaxWebApp.WebUI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjaxWebApp.WebUI.Context
{
    public class RepositoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01; initial Catalog=AjaxCustomerDb;integrated Security=true;trustServerCertificate=true");
        }
        public DbSet<Customer> Customers { get; set; }  
    }
}
