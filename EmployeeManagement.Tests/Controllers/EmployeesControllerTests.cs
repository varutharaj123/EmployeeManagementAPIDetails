using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagementAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EmployeeManagement.Tests.Controllers
{
    public class EmployeesControllerTests
    {
        private readonly Mock<IEmployeeService> _serviceMock;
        private readonly EmployeesController _controller;
        public EmployeesControllerTests()
        {

            _serviceMock = new Mock<IEmployeeService>();

            _controller = new EmployeesController(_serviceMock.Object);

        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {

            // Arrange
            var employees = new List<EmployeeDto>
            {

new EmployeeDto
{
EmployeeId=1,
EmployeeName="John"
}

            };

            _serviceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }


        [Fact]
        public async Task GetById_WhenEmployeeExists_ReturnOk()
        {

            // Arrange
            var employee =
                new EmployeeDto
                {
                    EmployeeId = 1,
                    EmployeeName = "David",
                    Email = "david@test.com"
                };

            _serviceMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(employee);

            // Act
            var result =
                await _controller.GetById(1);



            // Assert
            var okResult =
                Assert.IsType<OkObjectResult>(result);

            Assert.NotNull(okResult.Value);

        }


        [Fact]
        public async Task GetById_WhenEmployeeNotExists_ReturnNotFound()
        {


            // Arrange


            _serviceMock
                .Setup(x => x.GetByIdAsync(10))
                .ReturnsAsync((EmployeeDto)null);



            // Act


            var result =
                await _controller.GetById(10);



            // Assert


            Assert.IsType<NotFoundObjectResult>(result);


        }


        [Fact]
        public async Task Create_ShouldReturnCreated()
        {


            // Arrange


            var request =
                new CreateEmployeeDto
                {
                    EmployeeName = "Arun",
                    Email = "arun@test.com",
                    Department = "Development"
                };



            var response =
                new EmployeeDto
                {
                    EmployeeId = 1,
                    EmployeeName = "Arun"
                };



            _serviceMock
                .Setup(x => x.CreateAsync(request))
                .ReturnsAsync(response);



            // Act


            var result =
                await _controller.Create(request);



            // Assert


            var createdResult =
                Assert.IsType<CreatedAtActionResult>(
                    result);



            Assert.Equal(
                response,
                createdResult.Value);


        }


        [Fact]
        public async Task Update_WhenEmployeeExists_ReturnNoContent()
        {


            // Arrange


            var request =
                new UpdateEmployeeDto
                {
                    EmployeeName = "Updated Name"
                };



            _serviceMock
                .Setup(x => x.UpdateAsync(1, request))
                .ReturnsAsync(true);



            // Act


            var result =
                await _controller.Update(
                    1,
                    request);



            // Assert


            Assert.IsType<NoContentResult>(
                result);


        }




        [Fact]
        public async Task Update_WhenEmployeeNotExists_ReturnNotFound()
        {


            // Arrange


            var request =
                new UpdateEmployeeDto
                {
                    EmployeeName = "Test"
                };


            _serviceMock
                .Setup(x => x.UpdateAsync(1, request))
                .ReturnsAsync(false);



            // Act


            var result =
                await _controller.Update(
                    1,
                    request);



            // Assert


            Assert.IsType<NotFoundResult>(
                result);


        }





        [Fact]
        public async Task Delete_WhenEmployeeExists_ReturnNoContent()
        {


            // Arrange


            _serviceMock
                .Setup(x => x.DeleteAsync(1))
                .ReturnsAsync(true);



            // Act


            var result =
                await _controller.Delete(1);



            // Assert


            Assert.IsType<NoContentResult>(
                result);


        }


        [Fact]
        public async Task Delete_WhenEmployeeNotExists_ReturnNotFound()
        {


            // Arrange


            _serviceMock
                .Setup(x => x.DeleteAsync(1))
                .ReturnsAsync(false);



            // Act


            var result =
                await _controller.Delete(1);



            // Assert


            Assert.IsType<NotFoundResult>(
                result);


        }



    }
}
