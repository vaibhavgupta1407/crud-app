using CRUD.Models;
using CRUD.Models.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options) : base(options) { }
        public DbSet<employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> users { get; set; }
    }
}
