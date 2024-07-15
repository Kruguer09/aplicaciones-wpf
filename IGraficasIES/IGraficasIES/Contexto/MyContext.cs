using IGraficasIES.modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGraficasIES.Contexto
{
    internal class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = IGraficaIES_JoseAFerreRico;" +
                "Integrated Security = True; Connect Timeout = 30; Encrypt = False; " +
                "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        //creamos una tabla llamada Profesores
        //a partir de nuestra clase ProfesorFuncionario
        public DbSet<ProfesorFuncionario> Profesores { get; set; }
        //creamos una tabla llamada OtrosDatosProfesores
        //a partir de nuestra clase Extendido
        public DbSet<ProfesorExtendido> OtrosDatosProfesores { get; set; }
    }
}
