using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class TipoExameDbContext : DbContext
    {
        public DbSet<TipoExame> TipoExames { get; set; }
    }
}