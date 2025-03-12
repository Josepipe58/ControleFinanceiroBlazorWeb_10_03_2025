using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Ano
    {
        public int Id { get; set; }

        [Required( ErrorMessage = " O ano do cadastro é obrigatório.")]
        public int AnoDoCadastro { get; set; }
    }
}
