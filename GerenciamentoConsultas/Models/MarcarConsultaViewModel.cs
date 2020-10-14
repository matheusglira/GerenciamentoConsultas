using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class MarcarConsultaViewModel
    {
        public Int32 Protocolo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório", AllowEmptyStrings = false)]
        [Display(Name ="Data da Consulta")]
        public string DataConsulta { get; set; }

        [Required(ErrorMessage = "Selecione um Paciente", AllowEmptyStrings = false)]
        [Display(Name = "Paciente")]
        public Int32 PacienteId { get; set; }

        [Required(ErrorMessage = "Selecione um tipo de Exame", AllowEmptyStrings = false)]
        [Display(Name = "Tipo de Exame")]
        public Int32 TipoExameId { get; set; }
    }
}