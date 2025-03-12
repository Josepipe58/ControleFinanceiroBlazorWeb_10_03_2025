using Application.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CategoriaService : ControllerBase, ICategoriaService
    {
        public ICategoriaRepository _categoriaRepository;
        public ILogger<CategoriaService> _logger;

        public CategoriaService(ICategoriaRepository categoriaRepository, ILogger<CategoriaService> logger)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Categoria>> ObterListaDeCategorias()
        {
            var listaDeCategorias = await _categoriaRepository.ObterTodosAsync();
            if (listaDeCategorias is null)
            {
                NotFound("Erro! Não foi possivel obter uma lista de categorias.");
            }
            return listaDeCategorias;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _categoriaRepository.AdicionarAsync(categoria);
            return Ok(categoria);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarCategoria(Categoria categoria)
        {
            if (categoria is null) return BadRequest();
            await _categoriaRepository.EditarAsync(categoria);

            return Ok(categoria);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExcluirCategoria(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);
            if (categoria is null) return NotFound();

            await _categoriaRepository.ExcluirAsync(categoria.Id);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Categoria> ObterCategoriaPorId(int id)
        {
            var categoria = await _categoriaRepository.ObterPorIdAsync(id);
            if (categoria is null)
            {
                return null;
            }
            return categoria;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Categoria>> ObterCategoriasComFiltros()
        {
            var listaDeCategorias = await _categoriaRepository.ObterCategorias();
            if (listaDeCategorias is null)
            {
                NotFound("Erro! Não foi possivel obter uma lista de categorias.");
            }
            return listaDeCategorias;
        }
    }
}
