using PostAppApi.Comunicacao.ModelViews.Rating;
using PostAppApi.Domain.Models;

namespace PostAppApi.Application.Interfaces.Commons
{
    public interface IManager<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
