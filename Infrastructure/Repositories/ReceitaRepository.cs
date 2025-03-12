using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ReceitaRepository(AppDbContext context) : Repository<Receita>(context), IReceitaRepository
    {
    }
}
