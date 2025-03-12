namespace Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task<T> AdicionarAsync(T entity);
        Task<T> EditarAsync(T entity);
        Task ExcluirAsync(int id);
    }
}
