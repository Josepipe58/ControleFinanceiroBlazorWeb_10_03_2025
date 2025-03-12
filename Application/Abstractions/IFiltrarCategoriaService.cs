using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions
{
    public interface IFiltrarCategoriaService
    {
        Task<IEnumerable<FiltrarCategoria>> ObterListaDeFiltrarCategorias();
        Task<FiltrarCategoria> ObterFiltrarCategoriaPorId(int id);
        Task<IActionResult> AdicionarFiltrarCategoria(FiltrarCategoria filtrarCategoria);
        Task<IActionResult> EditarFiltrarCategoria(FiltrarCategoria filtrarCategoria);
        Task<IActionResult> ExcluirFiltrarCategoria(int id);
    }
}
