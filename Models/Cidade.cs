using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeAlunos.Models
{
    public class Cidade
    {
        public int CidadeId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        public int EstadoId { get; set; }
        public Estado? Estado { get; set; }


    }
}
