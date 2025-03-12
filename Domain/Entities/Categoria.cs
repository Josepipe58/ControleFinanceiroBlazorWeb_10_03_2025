using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {                
        }
        public Categoria(int id, string nomeDaCategoria, int filtrarCategoriaId, string nomeDoFiltro)
        {
            Id = id;
            NomeDaCategoria = nomeDaCategoria;
            FiltrarCategoriaId = filtrarCategoriaId;
            NomeDoFiltro = nomeDoFiltro;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " O nome da categoria é obrigatório."), StringLength(80)]
        public string NomeDaCategoria { get; set; }

        [ForeignKey(nameof(FiltrarCategoriaId))]
        public int FiltrarCategoriaId { get; set; }

        [NotMapped]
        public string NomeDoFiltro { get; set; }

        public virtual FiltrarCategoria FiltrarCategoria { get; set; }
    }
}
