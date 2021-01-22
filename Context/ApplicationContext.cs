using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.WebApi.Context
{
    public class ApplicationContext: DbContext, IApplicationContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
