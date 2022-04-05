using CarDealership.Data.Interfaces;
using CarDealership.Data.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.ComponentModel.DataAnnotations;
using WebCarDealership;
using WebCarDealership.Controllers;
using WebCarDealership.Requests;
using Xunit;

namespace CarDealership.Testing
{
    public class OrderControllerTests
    {
        private OrderController controllerSut;
        private Mock<IRepository> repoMockSut; 

        public OrderControllerTests()
        {
            repoMockSut = new Mock<IRepository>();
            controllerSut = new OrderController(repoMockSut.Object);
        }

        [Fact]
        public async void GivenAValidRequestModel_WhenCallingPost_ThenGettingAResponse()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                Make = "Dacia",
            };

            repoMockSut.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GivenAnNullModel_WhenCallingPost_ThenGettingNotFound()
        {
            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 12
            };

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<NotFoundObjectResult>();
        }

        //[Fact]
        //public async void GivenAIncompleteModel_WhenCallingPost_ThenGettingABadRequest()
        //{
        //    //Arrange
        //    var offer = new CarOffer()
        //    {
        //        Id = 1,
        //        Make = "Dacia",
        //    };

        //    repoMockSut.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

        //    var requestModel = new OrderRequestModel()
        //    {
        //        CarOfferId = 1,
        //        // CustomerId = null //this won't work
        //    };

        //    //Act
        //    var result = await controllerSut.Post(requestModel);

        //    //Assert
        //    result.Should().BeOfType<BadRequestObjectResult>();
        //}

        [Fact]
        public async void GivenQuantityGreaterThanStock_WhenCallingPost_ThenGettingBadRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                AvailableStock = 10
            }; 
            
            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 12
            };

            repoMockSut.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async void GivenStockDepletion_WhenCallingRepeatedPost_ThenGettingBadRequest()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                AvailableStock = 20
            };

            var firstRequestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 12
            };

            var secondRequestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                Quantity = 12
            };

            repoMockSut.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            //Act
            await controllerSut.Post(firstRequestModel);
            var result = await controllerSut.Post(secondRequestModel);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async void GivenAValidModel_WhenCallingPost_ThenGettingOk()
        {
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                AvailableStock = 20
            };

            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                CustomerId = 1,
                Quantity = 12
            };

            repoMockSut.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            //Act
            var result = await controllerSut.Post(requestModel);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void GivenAValidModel_WhenCallingPost_ThenCheckIfDatabaseSaved()
        {
            
            //Arrange
            var offer = new CarOffer()
            {
                Id = 1,
                AvailableStock = 20
            };
            
            var requestModel = new OrderRequestModel()
            {
                CarOfferId = 1,
                CustomerId = 1,
                Quantity = 12
            };

            repoMockSut.Setup(repo => repo.GetCarOfferById(It.IsAny<int>())).ReturnsAsync(offer);

            //Act
            await controllerSut.Post(requestModel);
            var order = repoMockSut.Setup(repo => repo.GetOrderById(1));

            //Assert
            order.Should().NotBeNull();
        }
    }
}