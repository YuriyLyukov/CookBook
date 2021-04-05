using API.Controllers.V1;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CookBook.Tests
{
    public class RecipeControllerTest
    {
        private RecipeController _controller;
        private IRecipeServices _services;

        public RecipeControllerTest()
        {
            _services = new RecipeServicesFake();
            _controller = new RecipeController(_services);
        }

        [Fact]
        public void Get_WhenCalled_ReturnOkResult()
        {
            //Act
            var okResult = _controller.Get(2);
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}