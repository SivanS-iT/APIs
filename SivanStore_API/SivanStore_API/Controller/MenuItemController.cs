using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Services;
using SivanStore_API.Abstractions;
using SivanStore_API.Data;
using SivanStore_API.Models;
using SivanStore_API.Models.Dto;
using SivanStore_API.Services;
using SivanStore_API.Utility;
using System.Net;

namespace SivanStore_API.Controller
{
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private readonly IMenuItemsRepository _menuItemsRepository;
        private ApiResponse _response;
         
        public MenuItemController(IBlobService blobService, IMenuItemsRepository menuItemsRepository)
        {  
            _blobService = blobService;
            _response = new ApiResponse();
            _menuItemsRepository = menuItemsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            _response.Result = await _menuItemsRepository.GetAll();
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
