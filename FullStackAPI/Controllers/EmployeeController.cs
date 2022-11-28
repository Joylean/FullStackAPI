using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
            var dependents = await dbContext.Dependents.ToListAsync();

            var result = from e in employee
                         join d in department on e.Department.Id equals d.Id
                         join p in project on e.Project.Id equals p.Id
                         join de in designation on e.Designation.Id equals de.Id
                         join dep in dependents on e.Dependent.Id equals dep.Id
                         select new
                         {
                             Id = e.Id,
                             EmployeeName = e.EmployeeName,
                             Department = d.DepartmentName,
                             Project = p.ProjectName,
                             Designation = de.DesignationName,
                             DateOfJoining = e.DateofJoining,
                             Email = e.Email,
                             PrimaryContactNumber = e.PrimaryContactNumber,
                             Location = d.Location,
                             ReportingManager = d.ReportingManager,
                             DependentName = dep.DependentName,
                             Relationship = dep.Relationship
                         };
            return Ok(result);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employeefound = await dbContext.Employees.FindAsync(id);

            if(employeefound != null)
            {
                var employee = await dbContext.Employees.ToListAsync();
                var department = await dbContext.Departments.ToListAsync();
                var project = await dbContext.Projects.ToListAsync();
                var designation = await dbContext.Designations.ToListAsync();
                var dependents = await dbContext.Dependents.ToListAsync();

                var result = from e in employee .Where(e => e.Id == id)
                             join d in department on e.Department.Id equals d.Id
                             join p in project on e.Project.Id equals p.Id
                             join de in designation on e.Designation.Id equals de.Id
                             join dep in dependents on e.Dependent.Id equals dep.Id
                             select new
                             {
                                 Id = e.Id,
                                 EmployeeName = e.EmployeeName,
                                 Department = d,
                                 Project = p,
                                 Designation = de,
                                 DateOfJoining = e.DateofJoining,
                                 Email = e.Email,
                                 PrimaryContactNumber = e.PrimaryContactNumber,
                                 Dependent = dep,
                             };
                return Ok(result);
            }

            return NotFound();
            
        }

        //saveDATA
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post(Employee addEmployeeRequest)
        {
            var empDetail = new Employee()
            {
                //Id = addEmployeeRequest.Id,
                EmployeeName = addEmployeeRequest.EmployeeName,
                Department = addEmployeeRequest.Department,
                Project = addEmployeeRequest.Project,
                Designation = addEmployeeRequest.Designation,
                DateofJoining = addEmployeeRequest.DateofJoining,
                Email = addEmployeeRequest.Email,
                PrimaryContactNumber = addEmployeeRequest.PrimaryContactNumber,
                Dependent = addEmployeeRequest.Dependent,
            };

            await dbContext.Employees.AddAsync(empDetail);
            await dbContext.SaveChangesAsync();

            return Ok(empDetail);
        }

        // Update
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Employee updateEmployeeRequest)
        {
            var employeefound = await dbContext.Employees.FindAsync(id);

            if (employeefound != null)
            {
                employeefound.EmployeeName = updateEmployeeRequest.EmployeeName;
                employeefound.Department = updateEmployeeRequest.Department;
                employeefound.Project = updateEmployeeRequest.Project;
                employeefound.Designation = updateEmployeeRequest.Designation;
                employeefound.DateofJoining = updateEmployeeRequest.DateofJoining;
                employeefound.Email = updateEmployeeRequest.Email;
                employeefound.PrimaryContactNumber = updateEmployeeRequest.PrimaryContactNumber;
                employeefound.Dependent = updateEmployeeRequest.Dependent;

                await dbContext.SaveChangesAsync();
                return Ok(employeefound);
            }
            
            return NotFound();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empfind = await dbContext.Employees.FindAsync(id);
            if (empfind != null)
            {
                dbContext.Remove(empfind);
                await dbContext.SaveChangesAsync();
                return Ok(empfind);
            }
            return NotFound();
        }
    }
}
