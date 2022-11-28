using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentController : ControllerBase
    {
        private readonly FullStackDbContext dbContext;

        public DependentController(FullStackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Dependents.ToListAsync());
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var depen = await dbContext.Dependents.FindAsync(id);
            if (depen == null)
            {
                return NotFound();
            }
            return Ok(depen);
        }
        // POST api/<DependentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var depen = new Dependent()
            {
                DependentName = value
            };

            await dbContext.Dependents.AddAsync(depen);
            await dbContext.SaveChangesAsync();

            return Ok(depen);
        }

        // PUT api/<DependentController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DependentController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
