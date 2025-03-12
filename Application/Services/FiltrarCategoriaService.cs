using Application.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class FiltrarCategoriaService : ControllerBase, IFiltrarCategoriaService
    {
        public IFiltrarCategoriaRepository _filtrarCategoriaRepository;
        public ILogger<FiltrarCategoriaService> _logger;

        public FiltrarCategoriaService(IFiltrarCategoriaRepository filtrarCategoriaRepository, ILogger<FiltrarCategoriaService> logger)
        {
            _filtrarCategoriaRepository = filtrarCategoriaRepository;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<FiltrarCategoria>> ObterListaDeFiltrarCategorias()
        {
            var listaDeCategorias = await _filtrarCategoriaRepository.ObterTodosAsync();
            if (listaDeCategorias is null)
            {
                NotFound("Erro! Não foi possivel obter uma lista de filtrarcategorias.");
            }
            return listaDeCategorias;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarFiltrarCategoria(FiltrarCategoria filtrarCategoria)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _filtrarCategoriaRepository.AdicionarAsync(filtrarCategoria);
            return Ok(filtrarCategoria);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarFiltrarCategoria(FiltrarCategoria filtrarCategoria)
        {
            if (filtrarCategoria is null) return BadRequest();
            await _filtrarCategoriaRepository.EditarAsync(filtrarCategoria);

            return Ok(filtrarCategoria);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExcluirFiltrarCategoria(int id)
        {
            var filtrarCategoria = await _filtrarCategoriaRepository.ObterPorIdAsync(id);
            if (filtrarCategoria is null) return NotFound();

            await _filtrarCategoriaRepository.ExcluirAsync(filtrarCategoria.Id);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<FiltrarCategoria> ObterFiltrarCategoriaPorId(int id)
        {
            var filtrarCategoria = await _filtrarCategoriaRepository.ObterPorIdAsync(id);
            if (filtrarCategoria is null)
            {
                return null;
            }
            return filtrarCategoria;
        }
    }
}
