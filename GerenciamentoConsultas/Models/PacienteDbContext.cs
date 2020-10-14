using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class PacienteDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
    }
}