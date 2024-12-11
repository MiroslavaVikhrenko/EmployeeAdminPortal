namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
        //the 4 properties from Employee so that we accept these data from user as parameters in Controller
        public required string Name { get; set; } //required =>  to initiaize Employee object we need to specify required properties (in db not null)
        public required string Email { get; set; }
        public string? Phone { get; set; } //? => phone can be null => nullable property
        public decimal Salary { get; set; }
    }
}
