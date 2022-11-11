using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HollywoodService.Models;

namespace HollywoodService.Data
{
    public class HollywoodServiceContext : DbContext
    {
        public HollywoodServiceContext (DbContextOptions<HollywoodServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
    }
}
