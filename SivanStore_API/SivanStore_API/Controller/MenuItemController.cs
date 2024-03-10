using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SivanStore_API.Data;

namespace SivanStore_API.Controller
{
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
         
        public MenuItemController(ApplicationDbContext db)
        {  
            _db = db; 
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            return Ok(_db.MenuItems);
        }
    }
}
