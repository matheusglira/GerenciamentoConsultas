using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciamentoConsultas.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "O nome do paciente é obrigatório", AllowEmptyStrings = false)]
        public string NomePaciente { get; set; }
        [Required(ErrorMessage = "CPF Obrigatório", AllowEmptyStrings = false)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Data de Nascimento é obrigatória", AllowEmptyStrings = false)]
        public string DataNascimento { get; set; }
        [Required(ErrorMessage = "Informe o sexo", AllowEmptyStrings = false)]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Informe o telefone para contato", AllowEmptyStrings = false)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o e-mail", AllowEmptyStrings = false)]
        public string Email { get; set; }
    }
}