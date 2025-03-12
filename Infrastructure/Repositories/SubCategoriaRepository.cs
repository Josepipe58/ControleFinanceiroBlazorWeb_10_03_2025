using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class SubCategoriaRepository(AppDbContext context) : Repository<SubCategoria>(context), ISubCategoriaRepository
    {
    }
}
