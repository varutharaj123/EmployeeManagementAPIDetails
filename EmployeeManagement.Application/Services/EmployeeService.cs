using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto request)
        {
            var employee = new Employee
            {
                EmployeeName = request.EmployeeName,
                Email = request.Email,
                Department = request.Department,
                DateOfJoining = request.DateOfJoining
            };

            var result = await _repository.AddAsync(employee);

            return MapToDto(result);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            return employees.Select(MapToDto);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return null;
            return MapToDto(employee);
        }

        public async Task<bool> UpdateAsync(int id, UpdateEmployeeDto request)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return false;

            employee.EmployeeName = request.EmployeeName;
            employee.Email = request.Email;
            employee.Department = request.Department;
            employee.DateOfJoining = request.DateOfJoining;
            await _repository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
                return false;

            await _repository.DeleteAsync(employee);
            return true;
        }

        private static EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Email = employee.Email,
                Department = employee.Department,
                DateOfJoining = employee.DateOfJoining

            };
        }
    }
}
