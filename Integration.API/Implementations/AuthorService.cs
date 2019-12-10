using System.Threading.Tasks;
using Integration.API.Interfaces;
using Integration.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration.API.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _dbContext.Authors.Include(p => p.Books).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Author> AddAsync(Author author)
        {
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();

            return author;
        }

        public async Task RemoveAsync(Author author)
        {
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}