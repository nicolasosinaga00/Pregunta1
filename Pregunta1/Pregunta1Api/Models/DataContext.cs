using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pregunta1Api.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base ("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Pregunta1Api.Models.Osinaga> Osinagas { get; set; }
    }
}