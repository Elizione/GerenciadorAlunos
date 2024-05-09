using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeAlunos.Models
{
    public class Estado
    {
        public int EstadoId { get; set; }

        [Required]
        [StringLength(2)]
        public string? UF { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

    }
}
