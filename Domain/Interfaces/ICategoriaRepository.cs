﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> ObterCategorias();
    }
}
