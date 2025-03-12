using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class FiltrarCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " O nome do filtro é obrigatório."), StringLength(30)]
        public string NomeDoFiltro { get; set; }
    }
}
