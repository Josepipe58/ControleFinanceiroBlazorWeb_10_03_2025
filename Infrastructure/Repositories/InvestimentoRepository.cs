using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class InvestimentoRepository(AppDbContext context) : Repository<Investimento>(context), IInvestimentoRepository
    {
    }
}
