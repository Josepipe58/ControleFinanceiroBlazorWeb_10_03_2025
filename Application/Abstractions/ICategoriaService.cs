using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Abstractions
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObterListaDeCategorias();
        Task<Categoria> ObterCategoriaPorId(int id);
        Task<IActionResult> AdicionarCategoria(Categoria categoria);
        Task<IActionResult> EditarCategoria(Categoria categoria);
        Task<IActionResult> ExcluirCategoria(int id);
        Task<IEnumerable<Categoria>> ObterCategoriasComFiltros();
    }
}
