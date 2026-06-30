using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById),
            new { id = result.EmployeeId },result);

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound(
                new
                {
                    message = "Employee not found"
                });

            }
            return Ok(result);
        }



        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDto request)
        {
            var result =await _service.UpdateAsync(id,request);

            if (!result)
                return NotFound();

            return NoContent();

        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();

        }
    }
}
