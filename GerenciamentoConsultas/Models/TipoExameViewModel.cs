using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class TipoExameViewModel
    {
        public Int32 TipoExameId { get; set; }
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Tipo de Exame")]
        public String NmTipoExame { get; set; }
    }
}