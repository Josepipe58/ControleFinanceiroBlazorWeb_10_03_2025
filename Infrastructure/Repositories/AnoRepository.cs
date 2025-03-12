using Domain.Entities;
using Infrastructure.Context;
using Domain.Interfaces;


namespace Infrastructure.Repositories
{
    public class AnoRepository(AppDbContext contexto) : Repository<Ano>(contexto), IAnoRepository
    {
        //public AnoRepository() : this(null) { }
      
    }
}
