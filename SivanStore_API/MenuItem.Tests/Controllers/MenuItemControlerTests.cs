using RedMango_API.Services;
using SivanStore_API.Data;
using SivanStore_API.Models;
using FakeItEasy;

using SivanStore_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivanStore_API.Tests.Controllers
{
    public class MenuItemControlerTests
    {
        private readonly ApplicationDbContext _db;
        private readonly IBlobService _blobService;
        private ApiResponse _response;
        public MenuItemControlerTests() 
        {
            _db = A.Fake<ApplicationDbContext>();
            _blobService = A.Fake<IBlobService>();
            _response = new ApiResponse();
        }


        [Fact]
        public void ManuItemController_GetMenuItems_ReturnOK()
        {
            //Arrange

            //Act

            //Assert

        }
    }




}
