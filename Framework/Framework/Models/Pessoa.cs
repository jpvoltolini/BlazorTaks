using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTask.Framework
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF/CNPJ é obrigatório.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos e o CNPJ 14 dígitos.")]

        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public string Tipo { get; set; } // Física ou Jurídica
    }
}
