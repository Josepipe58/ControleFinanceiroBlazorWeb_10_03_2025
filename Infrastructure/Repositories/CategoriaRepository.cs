using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    //public class CategoriaRepository(AppDbContext context) : Repository<Categoria>(context), ICategoriaRepository
    //{

    //}
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public new AppDbContext _context;
        public CategoriaRepository(AppDbContext contexto) : base(contexto)
        {
            _context = contexto;
        }
        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            List<Categoria> lCategorias = await _context.TCategoria.ToListAsync();
            List<FiltrarCategoria> lFiltroDeControles = await _context.TFiltrarCategoria.ToListAsync();
            var listaDeCategorias = lCategorias.GroupJoin(lCategorias,
                c => c.FiltrarCategoriaId,
                fc => fc.Id,
                (c, scGrupo) => new Categoria(
                    c.Id,
                    c.NomeDaCategoria,
                    c.FiltrarCategoriaId,
                    c.FiltrarCategoria.NomeDoFiltro
                    )).OrderByDescending(c => c.Id);

            return [.. listaDeCategorias];
        }
    }
}
    
