using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SubCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " O nome da subcategoria é obrigatório"), StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public int CategoriaId { get; set; }

        [NotMapped]
        public string NomeDaCategoria { get; set; }

        [NotMapped]
        public int FiltrarCategoriaId { get; set; }

        [NotMapped]
        public string NomeDoFiltro { get; set; }

        //Relacionamento
        public virtual Categoria Categoria { get; set; }
    }
}
