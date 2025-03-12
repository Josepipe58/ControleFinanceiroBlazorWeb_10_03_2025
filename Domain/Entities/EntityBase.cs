using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = " O nome da categoria é obrigatório."), StringLength(100)]
        public string NomeDaCategoria { get; set; }

        //[Required(ErrorMessage = " O nome da descrição é obrigatório"), StringLength(500)]
        //public string Descricao { get; set; }

        [Required, StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [Required(ErrorMessage = " O valor é obrigatório."), Column(TypeName = "decimal(10, 2)"), 
         DisplayFormat(DataFormatString = "{0:C2}"), DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = " O nome do tipo é obrigatório."), StringLength(30)]
        public string Tipo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Required, StringLength(20)]
        public string Mes { get; set; }

        public int Ano { get; set; }
    }
}
