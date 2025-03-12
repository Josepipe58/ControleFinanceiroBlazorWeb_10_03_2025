using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class DespesaRepository(AppDbContext context) : Repository<Despesa>(context), IDespesaRepository
    {
    }
}
