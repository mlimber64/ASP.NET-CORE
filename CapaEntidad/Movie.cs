using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_movie.CapaEntidad
{
    public class Movie
    {
        public int Id {get;set;}
        public string Director {get;set;}
        public string Gener {get;set;}
        public int Year{get;set;}
        public string Duration{get;set;}
        public string Synopsis {get;set;}
        public bool Active {get;set;}
    }
}