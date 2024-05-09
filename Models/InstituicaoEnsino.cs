using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeAlunos.Models
{
    public class InstituicaoEnsino
    {
        public int InstituicaoEnsinoId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
    }
}
