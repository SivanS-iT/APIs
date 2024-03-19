using Azure;
using Microsoft.EntityFrameworkCore;
using SivanStore_API.Abstractions;
using SivanStore_API.Data;
using SivanStore_API.Models;

namespace SivanStore_API.Repositories
{
    public class MenuItemsRepository : IMenuItemsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MenuItemsRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<MenuItem>> GetAll()
        {
            return await _dbContext.Set<MenuItem>().ToListAsync();
        }
    }
}
