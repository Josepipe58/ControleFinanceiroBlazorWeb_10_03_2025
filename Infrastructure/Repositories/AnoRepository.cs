using Domain.Entities;
using Infrastructure.Context;
using Domain.Interfaces;


namespace Infrastructure.Repositories
{
    public class AnoRepository(AppDbContext context) : Repository<Ano>(context), IAnoRepository
    {
        //public AnoRepository() : this(null) { }
      
    }
}
