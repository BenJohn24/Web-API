using SubirWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SubirWebAPI.Data
{
    public class ContextoVolumen: DbContext
    {
        public ContextoVolumen() : base("name=conexionLibro") { }

        public DbSet<Obra> Obras { get; set; }
    }
}