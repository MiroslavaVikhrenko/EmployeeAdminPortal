using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    //localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //inject db context 
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //add endpoints

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            //we use dto to add data (AddEmployeeDto from Models)
            //map addEmployeeDto and convert into Entity we have => because db context only accept entity and we want to add a new employee to the db

            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            //Entities are separated from dto => by adding dto we achieve separation of concern
            //we expose dto to the outside world while entity is an image of the table in db
            //we could have different names for dbo and entity properties

            dbContext.Employees.Add(employeeEntity); //this line does NOT add a new employee to the db, you need to save the changes yourself
            dbContext.SaveChanges(); //only here the employee will be saved to the db table

            return Ok(employeeEntity); //ideally we want to return 201 which is CREATED response but to simplify we will just return Ok

            //We did not initialize an id - it will be added for us by entity framework and it will be return to the user as well
        }
    }
}
