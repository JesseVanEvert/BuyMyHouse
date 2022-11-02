using BuyMyHouse.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.DAL
{
    public class Context : DbContext
    {
        public DbSet<House> House { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Person> Person { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}
