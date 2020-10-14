using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    [Table("MarcarConsulta")]
    public class MarcarConsulta
    {
        [Key]
        public int Protocolo { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        public string DataConsulta { get; set; }

        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        public int TipoExameId { get; set; }
        public virtual TipoExame TipoExame { get; set; }
    }
}