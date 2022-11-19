using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly FullStackDbContext dbContext;

        public EmployeeController(FullStackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employee = await dbContext.Employees.ToListAsync();
            var department = await dbContext.Departments.ToListAsync();
            var project = await dbContext.Projects.ToListAsync();
            var designation = await dbContext.Designations.ToListAsync();

            var result = from e in employee
                         join d in department on e.Department.Id equals d.Id
                         join p in project on e.Project.Id equals p.Id
                         join de in designation on e.Designation.Id equals de.Id
                         select new
                         {
                             EmployeeName = e.EmployeeName,
                             Department = d.DepartmentName,
                             Project = p.ProjectName,
                             Designation = de.DesignationName,
                             DateOfJoining = e.DateofJoining,
                             Email = e.Email,
                             PrimaryContactNumber = e.PrimaryContactNumber,
                             Location = e.Location,
                             ReportingManager = e.ReportingManager,
                         };
            return Ok(result);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
