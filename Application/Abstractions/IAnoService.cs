using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions
{
    public interface IAnoService
    {
        Task<IEnumerable<Ano>> ObterListaDeAnos();
        Task<Ano> ObterAnoPorId(int id);
        Task<IActionResult> AdicionarAno(Ano ano);
        Task<IActionResult> EditarAno(Ano ano);
        Task<IActionResult> ExcluirAno(int id);
    }
}
