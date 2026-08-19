
using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static readonly List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                Name = "Arun Kumar",
                Email = "arun@example.com",
                Department = "Developer"
            },

            new Employee
            {
                Id = 2,
                Name = "Priya Sharma",
                Email = "priya@example.com",
                Department = "Designer"
            }
        };


        // GET: api/employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }


        // GET: api/employees/1
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        // POST: api/employees
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employee.Id = employees.Count + 1;

            employees.Add(employee);

            return CreatedAtAction(
                nameof(GetEmployee),
                new { id = employee.Id },
                employee
            );
        }


        // PUT: api/employees/1
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Department = updatedEmployee.Department;

            return Ok(employee);
        }


        // DELETE: api/employees/1
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employees.Remove(employee);

            return NoContent();
        }
    }
}