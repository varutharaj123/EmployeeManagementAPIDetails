using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {

            _context = context;

        }

        //public async Task<Employee> AddAsync(Employee employee)
        //{
        //    var staticEmployee = new Employee
        //    {
        //        EmployeeId = 1,
        //        EmployeeName = employee.EmployeeName,
        //        Email = employee.Email,
        //        Department = employee.Department,
        //        DateOfJoining = employee.DateOfJoining
        //    };

        //    return await Task.FromResult(staticEmployee);
        //}

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

    //    public async Task<IEnumerable<Employee>> GetAllAsync()
    //    {
    //        var employees = new List<Employee>
    //{
    //    new Employee
    //    {
    //        EmployeeId = 1,
    //        EmployeeName = "John Smith",
    //        Email = "john.smith@gmail.com",
    //        Department = "Software Development",
    //        DateOfJoining = new DateTime(2024, 1, 10)
    //    },

    //    new Employee
    //    {
    //        EmployeeId = 2,
    //        EmployeeName = "David Kumar",
    //        Email = "david.kumar@gmail.com",
    //        Department = "Testing",
    //        DateOfJoining = new DateTime(2023, 6, 15)
    //    },

    //    new Employee
    //    {
    //        EmployeeId = 3,
    //        EmployeeName = "Priya Sharma",
    //        Email = "priya.sharma@gmail.com",
    //        Department = "HR",
    //        DateOfJoining = new DateTime(2022, 9, 20)
    //    }
    //};


    //        return await Task.FromResult(employees);
    //    }
        public async Task<IEnumerable<Employee>> GetAllAsync() 
        { 
            return await _context.Employees.AsNoTracking().ToListAsync(); 
        }


        //    public async Task<Employee?> GetByIdAsync(int id, UpdateEmployeeDto updateEmployeeDto)
        //    {
        //        var employees = new List<Employee>
        //{
        //    new Employee
        //    {
        //        EmployeeId = 1,
        //        EmployeeName = "John Smith",
        //        Email = "john.smith@gmail.com",
        //        Department = "Software Development",
        //        DateOfJoining = new DateTime(2024, 1, 10)
        //    },

        //    new Employee
        //    {
        //        EmployeeId = 2,
        //        EmployeeName = "David Kumar",
        //        Email = "david.kumar@gmail.com",
        //        Department = "Testing",
        //        DateOfJoining = new DateTime(2023, 6, 15)
        //    },

        //    new Employee
        //    {
        //        EmployeeId = 3,
        //        EmployeeName = "Priya Sharma",
        //        Email = "priya.sharma@gmail.com",
        //        Department = "HR",
        //        DateOfJoining = new DateTime(2022, 9, 20)
        //    }
        //};
        //        var employee = employees.FirstOrDefault(x => x.EmployeeId == id);
        //        return await Task.FromResult(employee);
        //    }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId == id);
        }


        //public async Task UpdateAsync(Employee employee)
        //{
        //    var existingEmployee = employees
        //        .FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);


        //    if (existingEmployee != null)
        //    {
        //        existingEmployee.EmployeeName = employee.EmployeeName;

        //        existingEmployee.Email = employee.Email;

        //        existingEmployee.Department = employee.Department;

        //        existingEmployee.DateOfJoining = employee.DateOfJoining;
        //    }


        //    await Task.CompletedTask;
        //}
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        //        private static readonly List<Employee> employees = new()
        //{
        //    new Employee
        //    {
        //        EmployeeId = 1,
        //        EmployeeName = "John Smith",
        //        Email = "john@gmail.com",
        //        Department = "IT",
        //        DateOfJoining = new DateTime(2024,1,10)
        //    },

        //    new Employee
        //    {
        //        EmployeeId = 2,
        //        EmployeeName = "David Kumar",
        //        Email = "david@gmail.com",
        //        Department = "Testing",
        //        DateOfJoining = new DateTime(2023,5,15)
        //    }
        //};


        //public async Task DeleteAsync(Employee employee)
        //{
        //    var existingEmployee = employees
        //        .FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);


        //    if (existingEmployee != null)
        //    {
        //        employees.Remove(existingEmployee);
        //    }


        //    await Task.CompletedTask;
        //}
        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}