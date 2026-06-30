using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto request);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id,UpdateEmployeeDto request);
        Task<bool> DeleteAsync(int id);
    }
}
