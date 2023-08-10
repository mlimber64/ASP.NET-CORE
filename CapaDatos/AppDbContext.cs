using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using prueba_movie.CapaEntidad;

namespace prueba_movie.CapaDatos
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options){}
        

        public DbSet<Movie> Movies {get;set;}
    }
}