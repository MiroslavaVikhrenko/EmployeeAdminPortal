namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDto
    {
        //here we specify what we can update
        public required string Name { get; set; } 
        public required string Email { get; set; }
        public string? Phone { get; set; } 
        public decimal Salary { get; set; }
    }
}
