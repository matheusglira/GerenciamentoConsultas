using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    [Table("TipoExame")]
    public class TipoExame
    {
        public int TipoExameId { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        public string NmTipoExame { get; set; }
        
        public List<CadastroExame> CadastroExames { get; set; }
    }
}