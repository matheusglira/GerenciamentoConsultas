using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class CadastroExameViewModel
    {
        public Int32 CadastroExameId { get; set; }
        [Required(ErrorMessage = "Nome do exame é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Exame")]
        public String NomeExame { get; set; }
        public String Observacao{ get; set; }
        [Required(ErrorMessage = "Selecione uma Tipo", AllowEmptyStrings = false)]
        [Display(Name = "TipoExame")]
        public Int32 TipoExameId { get; set; }
    }
}