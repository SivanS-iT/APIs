using RedMango_API.Services;
using SivanStore_API.Data;
using FakeItEasy;

using SivanStore_API.Abstractions;
using SivanStore_API.Models;
using SivanStore_API.Controller;
using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace SivanStore_API.Tests.Controllers
{
    public class MenuItemControllerTests
    {
        private readonly IMenuItemsRepository _menuItemsRepository;
        private readonly IBlobService _blobService;
        private ApiResponse _response;

        private static readonly List<Models.MenuItem> MenuItemsList =
    [
        new Models.MenuItem { Id = 1, Name = "name", Image="image"}
    ];
        public MenuItemControllerTests() 
        {
            _blobService = A.Fake<IBlobService>();
            _menuItemsRepository = A.Fake<IMenuItemsRepository>();
            _response = new ApiResponse();
        }


        [Fact]
        public void ManuItemController_GetMenuItems_ReturnOK()
        {
            //Arrange
            A.CallTo(() => _menuItemsRepository.GetAll()).Returns(MenuItemsList);
            var controller = new MenuItemController(_blobService, _menuItemsRepository);

            //Act
            var response = controller.GetMenuItems();

            //Assert
            response.Result.Should().BeOfType(typeof(OkObjectResult));
        }
    }




}
