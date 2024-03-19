using SivanStore_API.Models;

namespace SivanStore_API.Abstractions
{
    public interface IMenuItemsRepository
    {
        Task<IReadOnlyList<MenuItem>> GetAll();
    }
}
