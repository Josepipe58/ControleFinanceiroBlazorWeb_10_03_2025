using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class FiltrarCategoriaRepository(AppDbContext context) : Repository<FiltrarCategoria>(context), IFiltrarCategoriaRepository
    {
    }
}
