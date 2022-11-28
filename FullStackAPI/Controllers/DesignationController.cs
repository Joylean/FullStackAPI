using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly FullStackDbContext dbContext;

        public DesignationController(FullStackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Designations.ToListAsync());
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var desi = await dbContext.Designations.FindAsync(id);
            if (desi == null)
            {
                return NotFound();
            }
            return Ok(desi);
        }
        // POST api/<DesignationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            var desi = new Designation()
            {
                DesignationName = value
            };

            await dbContext.Designations.AddAsync(desi);
            await dbContext.SaveChangesAsync();

            return Ok(desi);
        }

        // PUT api/<DesignationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DesignationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
