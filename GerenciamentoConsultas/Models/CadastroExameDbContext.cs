using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GerenciamentoConsultas.Models
{
    public class CadastroExameDbContext : DbContext
    {
        public DbSet<CadastroExame> CadastroExame { get; set; }
        public DbSet<TipoExame> TipoExames { get; set; }
    }
}