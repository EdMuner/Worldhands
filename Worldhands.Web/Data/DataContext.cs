using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worldhands.Web.Data.Entities;

namespace Worldhands.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {      
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
