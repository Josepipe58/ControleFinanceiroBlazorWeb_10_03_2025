using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class PoupancaRepository(AppDbContext context) : Repository<Poupanca>(context), IPoupancaRepository
    {
    }
}
