using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    public class PacienteViewModel
    {
        public Int32 PacienteId { get; set; }
        public string NomePaciente { get; set; }
        [Required(ErrorMessage = "CPF Obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "CPF")]
        public String Cpf { get; set; }
        [Required(ErrorMessage = "Data de Nascimento é obrigatória", AllowEmptyStrings = false)]
        [Display(Name = "Data de Nascimento")]
        public String DataNascimento { get; set; }
        [Required(ErrorMessage = "Informe o sexo", AllowEmptyStrings = false)]
        [Display(Name = "Sexo")]
        public String Sexo { get; set; }
        [Required(ErrorMessage = "Informe o telefone para contato", AllowEmptyStrings = false)]
        [Display(Name = "Telefone")]
        public String Telefone { get; set; }
        [Required(ErrorMessage = "Informe o e-mail", AllowEmptyStrings = false)]
        [Display(Name = "E-mail")]
        public String Email { get; set; }
    }
}