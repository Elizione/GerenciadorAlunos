using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeAlunos.Models
{
     public class Aluno
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato de CPF inválido")]
        public string? Cpf { get; set; }

        [Required]
        [StringLength(200)]
        public string? Endereco { get; set; }

        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public Estado? Estado { get; set; }

        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }
        public Cidade? Cidade { get; set; }

        [Display(Name = "InstituicaoEnsino")]
        public int InstituicaoEnsinoId { get; set; }
        public InstituicaoEnsino? InstituicaoEnsino { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomeCurso { get; set; }

        [Required]
        public DateTime DataConclusao { get; set; }

       public string FormatarCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11 || !long.TryParse(cpf, out _))
                throw new ArgumentException("CPF inválido.");

            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9)}";
        }
    }
}
