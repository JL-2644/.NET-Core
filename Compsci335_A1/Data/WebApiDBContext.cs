using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Compsci335_A1.Models;

namespace Compsci335_A1.Data
{
    public class WebApiDBContext : DbContext 
    {
        public WebApiDBContext(DbContextOptions<WebApiDBContext> options) : base(options) { }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Comments> comments { get; set; }

    }
}
