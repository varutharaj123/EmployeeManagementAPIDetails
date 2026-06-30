namespace EmployeeManagement.Application.DTOs
{
    public class CreateEmployeeDto
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime DateOfJoining { get; set; }
    }
}
