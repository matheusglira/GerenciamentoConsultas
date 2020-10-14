using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class MarcarExameDbContext : DbContext
    {
        public DbSet<MarcarConsulta> MarcarConsultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoExame> TipoExames { get; set; }
    }
}