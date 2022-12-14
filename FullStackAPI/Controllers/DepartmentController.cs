using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly FullStackDbContext dbContext;

        public DepartmentController(FullStackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<DepartmentController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var department = await dbContext.Departments.ToListAsync();

            return Ok(department);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dept = await dbContext.Departments.FindAsync(id);
            if (dept == null)
            {
                return NotFound();
            }
            return Ok(dept);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var dept = new Department()
            {
                DepartmentName = value
            };

            await dbContext.Departments.AddAsync(dept);
            await dbContext.SaveChangesAsync();

            return Ok(dept);
        }

        // PUT api/<DepartmentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DepartmentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
