namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } //required =>  to initiaize Employee object we need to specify required properties (in db not null)
        public required string Email { get; set; }
        public string? Phone { get; set; } //? => phone can be null => nullable property
        public decimal Salary { get; set; }
    }
}
