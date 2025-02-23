using AspNetCoreEmpty.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace AspNetCoreEmpty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADOController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ADOController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("getallusers")]
        public async Task<IActionResult> Get()
        {
            var results = await _dbContext.ApplicationUsers
                .FromSqlRaw("SELECT * FROM AspNetUsers").ToListAsync();

            return Ok(results);
        }
        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _dbContext.ApplicationUsers
                .FromSqlRaw("SELECT * FROM AspNetUsers WHERE Id = {0}", id).FirstOrDefaultAsync();
            return Ok(result);
        }
        [HttpGet("cube/{num}")]
        public async Task<IActionResult> Cube(int num)
        
        {
            

            var result = await _dbContext.Products
                .FromSqlRaw("EXECUTE sp_Cube @num",
                new SqlParameter("@num", num)).ToListAsync();

            return Ok(result);
        }
    }
}
