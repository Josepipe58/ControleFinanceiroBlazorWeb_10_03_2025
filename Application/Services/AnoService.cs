using Application.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AnoService : ControllerBase, IAnoService
    {
        public IAnoRepository _anoRepository;
        public ILogger<AnoService> _logger;

        public AnoService(IAnoRepository anoRepository, ILogger<AnoService> logger)
        {
            _anoRepository = anoRepository;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Ano>> ObterListaDeAnos()
        {
            var listaDeAnos = await _anoRepository.ObterTodosAsync();
            if (listaDeAnos is null)
            {
                NotFound("Erro! Não foi possivel obter uma lista de anos.");
            }
            return listaDeAnos;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarAno(Ano ano)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _anoRepository.AdicionarAsync(ano);
            return Ok(ano);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarAno(Ano ano)
        {
            if (ano is null) return BadRequest();
            await _anoRepository.EditarAsync(ano);

            return Ok(ano);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ExcluirAno(int id)
        {
            var ano = await _anoRepository.ObterPorIdAsync(id);
            if (ano is null) return NotFound();

            await _anoRepository.ExcluirAsync(ano.Id);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Ano> ObterAnoPorId(int id)
        {
            var ano = await _anoRepository.ObterPorIdAsync(id);
            if (ano is null)
            {
                return null;
            }
            return ano;
        }
    }
}
