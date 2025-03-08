using Microsoft.EntityFrameworkCore;
using BeastStoreMvc.Models;
using System;


namespace BeastStoreMvc.Models
{ 
    public class TodoContext : DbContext
{
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
    
        public DbSet<CategoryMaster> CategoryMaster { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
    }
}