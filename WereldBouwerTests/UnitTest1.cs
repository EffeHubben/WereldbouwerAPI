//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Moq;
//using WereldbouwerAPI;
//using WereldbouwerAPI.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Xunit;

//namespace WereldBouwerTests
//{
//    public class WereldBouwerControllerTests
//    {
//        private readonly Mock<IWereldBouwerRepository> _mockRepo;
//        private readonly Mock<ILogger<WereldBouwerController>> _mockLogger;
//        private readonly WereldBouwerController _controller;
//        private readonly HttpClient _client;

//        public WereldBouwerControllerTests()
//        {
//            _mockRepo = new Mock<IWereldBouwerRepository>();
//            _mockLogger = new Mock<ILogger<WereldBouwerController>>();
//            _controller = new WereldBouwerController(_mockRepo.Object, _mockLogger.Object);
//            _client = new HttpClient(); // Initialize HttpClient for making HTTP requests
//        }

//        [Fact]
//        public async Task Get_ReturnsAllWereldBouwers()
//        {
//            // Arrange
//            var wereldBouwers = new List<WereldBouwer>
//            {
//                new WereldBouwer { id = Guid.NewGuid(), name = "Test1" },
//                new WereldBouwer { id = Guid.NewGuid(), name = "Test2" }
//            };
//            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(wereldBouwers);

//            // Act
//            var result = await _controller.Get();

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//            var returnValue = Assert.IsType<List<WereldBouwer>>(okResult.Value);
//            Assert.Equal(2, returnValue.Count);
//        }

//        [Fact]
//        public async Task Get_ById_ReturnsWereldBouwer()
//        {
//            // Arrange
//            var wereldBouwerId = Guid.NewGuid();
//            var wereldBouwer = new WereldBouwer { id = wereldBouwerId, name = "Test" };
//            _mockRepo.Setup(repo => repo.GetByIdAsync(wereldBouwerId)).ReturnsAsync(wereldBouwer);

//            // Act
//            var result = await _controller.Get(wereldBouwerId);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//            var returnValue = Assert.IsType<WereldBouwer>(okResult.Value);
//            Assert.Equal(wereldBouwerId, returnValue.id);
//        }

//        [Fact]
//        public async Task Post_CreatesNewWereldBouwer()
//        {
//            // Arrange
//            var wereldBouwer = new WereldBouwer { name = "Test" };
//            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<WereldBouwer>())).ReturnsAsync(wereldBouwer);

//            // Act
//            var result = await _controller.Post(wereldBouwer);

//            // Assert
//            var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result);
//            var returnValue = Assert.IsType<WereldBouwer>(createdAtRouteResult.Value);
//            Assert.Equal(wereldBouwer.name, returnValue.name);
//        }

//        [Fact]
//        public async Task Put_UpdatesExistingWereldBouwer()
//        {
//            // Arrange
//            var wereldBouwerId = Guid.NewGuid();
//            var existingWereldBouwer = new WereldBouwer { id = wereldBouwerId, name = "Existing" };
//            var updatedWereldBouwer = new WereldBouwer { id = wereldBouwerId, name = "Updated" };
//            _mockRepo.Setup(repo => repo.GetByIdAsync(wereldBouwerId)).ReturnsAsync(existingWereldBouwer);
//            _mockRepo.Setup(repo => repo.UpdateAsync(updatedWereldBouwer)).Returns(Task.CompletedTask);

//            // Act
//            var result = await _controller.Put(wereldBouwerId, updatedWereldBouwer);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnValue = Assert.IsType<WereldBouwer>(okResult.Value);
//            Assert.Equal(updatedWereldBouwer.name, returnValue.name);
//        }

//        [Fact]
//        public async Task Delete_ExistingWereldBouwer_ReturnsNoContent()
//        {
//            // Arrange
//            var existingWereldBouwer = await CreateWereldBouwerAsync(); // Method to create a WereldBouwer for the test
//            var id = existingWereldBouwer.id;

//            // Act
//            var response = await _client.DeleteAsync($"/WereldBouwer/{id}");

//            // Assert
//            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

//            // Optional: Verify that the WereldBouwer is actually deleted
//            var getResponse = await _client.GetAsync($"/WereldBouwer/{id}");
//            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
//        }

//        private async Task<WereldBouwer> CreateWereldBouwerAsync()
//        {
//            var wereldBouwer = new WereldBouwer { id = Guid.NewGuid(), name = "Test" };
//            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<WereldBouwer>())).ReturnsAsync(wereldBouwer);
//            await _controller.Post(wereldBouwer);
//            return wereldBouwer;
//        }
//    }
//}

