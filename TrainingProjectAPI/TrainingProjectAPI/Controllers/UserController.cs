using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingProjectAPI.Data;
using TrainingProjectAPI.DTOs;
using TrainingProjectAPI.Models;

namespace TrainingProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly TPDataContext dbContext;

        public UserController(TPDataContext dataContext)
        {

            this.dbContext = dataContext;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> AddUser(AddUserDTO addUser)
        {

            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == addUser.Email);

            if (user != null)
            {
                return BadRequest("This account exsits.");
            }

            var newuser = new User(addUser);

            await dbContext.Users.AddAsync(newuser);

            await dbContext.SaveChangesAsync();

            return Ok(newuser);
        }

    }
}
