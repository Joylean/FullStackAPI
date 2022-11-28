using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly FullStackDbContext dbContext;

        public ProjectController(FullStackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Projects.ToListAsync());
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var proj = await dbContext.Projects.FindAsync(id);
            if (proj == null)
            {
                return NotFound();
            }
            return Ok(proj);
        }
        // POST api/<ProjectController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var proj = new Project()
            {
                ProjectName = value
            };

            await dbContext.Projects.AddAsync(proj);
            await dbContext.SaveChangesAsync();

            return Ok(proj);
        }

        // PUT api/<ProjectController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProjectController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
