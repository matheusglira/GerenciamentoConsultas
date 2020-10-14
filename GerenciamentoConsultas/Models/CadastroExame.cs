using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    [Table("CadastroExame")]
    public class CadastroExame
    {
        public int CadastroExameId { get; set; }
        [Required(ErrorMessage = "O nome do Exame é obrigatório", AllowEmptyStrings = false)]
        public string NomeExame { get; set; }
        public string Observacao { get; set; }
        public int TipoExameid { get; set; }

        public virtual TipoExame TipoExame { get; set; }
    }
}