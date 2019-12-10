using System.Threading.Tasks;
using Integration.API.Models;

namespace Integration.API.Interfaces
{
    public interface IAuthorService
    {
        Task<Author> GetByIdAsync(int id);
        Task<Author> AddAsync(Author author);
        Task RemoveAsync(Author author);
    }
}