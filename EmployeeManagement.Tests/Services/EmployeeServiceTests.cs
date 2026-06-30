using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using Moq;
using Xunit;

namespace EmployeeManagement.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository>  _repositoryMock;

        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _repositoryMock =new Mock<IEmployeeRepository>();
            _service = new EmployeeService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmployees()
        {
            // Arrange
            var employees =new List<Employee>
            {
                new Employee
{
EmployeeId=1,
EmployeeName="John",
Email="john@test.com",
Department="IT"
}

            };
            _repositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("John",
            result.First().EmployeeName);


        }

        [Fact]
        public async Task GetByIdAsync_WhenEmployeeExists_ReturnEmployee()
        {

            // Arrange

            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "David",
                Email = "david@test.com",
                Department = "Testing"
            };


            _repositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(employee);



            // Act

            var result =
                await _service.GetByIdAsync(1);



            // Assert


            Assert.NotNull(result);

            Assert.Equal(
                "David",
                result.EmployeeName);

        }




        [Fact]
        public async Task GetByIdAsync_WhenEmployeeNotExists_ReturnNull()
        {

            // Arrange


            _repositoryMock
                .Setup(x => x.GetByIdAsync(10))
                .ReturnsAsync((Employee)null);



            // Act

            var result =
                await _service.GetByIdAsync(10);



            // Assert

            Assert.Null(result);

        }




        [Fact]
        public async Task CreateAsync_ShouldCreateEmployee()
        {


            // Arrange


            var employee =
            new Employee
            {
                EmployeeId = 1,
                EmployeeName = "Arun",
                Email = "arun@test.com",
                Department = "Development"
            };



            _repositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Employee>()))
            .ReturnsAsync(employee);



            var request =
            new CreateEmployeeDto
            {
                EmployeeName = "Arun",
                Email = "arun@test.com",
                Department = "Development"
            };



            // Act


            var result =
                await _service.CreateAsync(request);



            // Assert


            Assert.NotNull(result);

            Assert.Equal(
                "Arun",
                result.EmployeeName);


            _repositoryMock.Verify(
            x => x.AddAsync(It.IsAny<Employee>()),
            Times.Once);


        }



        [Fact]
        public async Task UpdateAsync_WhenEmployeeExists_ReturnTrue()
        {


            // Arrange


            var employee =
            new Employee
            {
                EmployeeId = 1,
                EmployeeName = "Old Name"
            };


            _repositoryMock
            .Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(employee);



            _repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Employee>())).Returns(Task.CompletedTask);

            var request =
            new UpdateEmployeeDto
            {
                EmployeeName = "Updated Name"
            };



            // Act
            var result =
            await _service.UpdateAsync(1, request);

            // Assert

            Assert.True(result);
            _repositoryMock.Verify(
            x => x.UpdateAsync(
            It.IsAny<Employee>()),
            Times.Once);


        }




        [Fact]
        public async Task DeleteAsync_WhenEmployeeExists_ReturnTrue()
        {
            // Arrange
            var employee =
            new Employee
            {
                EmployeeId = 1
            };

            _repositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(employee);

            _repositoryMock.Setup(x => x.DeleteAsync(employee)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.DeleteAsync(1);

            // Assert
            Assert.True(result);
            _repositoryMock.Verify(x => x.DeleteAsync(employee),Times.Once);

        }

    }
}
