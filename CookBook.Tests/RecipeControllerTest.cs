using System.Collections.Generic;
using API.Controllers.V1;
using API.Domain;
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

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(8)]
        public void GetById_WhenCalled_ReturnOkResult(int id)
        {
            //Act
            var okResult = _controller.Get(id);
            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetAll_WhenCalled_ReturnsAllItems()
        {
            var okResult =  _controller.Getall().Result as OkObjectResult;
            var recipes = Assert.IsType<List<Recipe>>(okResult.Value);
            Assert.Equal(8, recipes.Count);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult(int id)
        {
            // Act
            var notFoundResult = _controller.Get(id);
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
    }
}