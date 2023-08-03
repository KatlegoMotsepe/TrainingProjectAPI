using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTrainingProjectAPI.Data;
using NewTrainingProjectAPI.DTOs;
using NewTrainingProjectAPI.Models;

namespace NewTrainingProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            this._context = context;
        }

        [HttpPost("Register")] //Over explaining is a thing.
        public async Task<IActionResult> RegiterUSer(AddUserDTO addUser)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == addUser.Email);

            if (user != null) { return BadRequest("This email is used alreday"); }

            await _context.Users.AddAsync(new User(addUser));
            await _context.SaveChangesAsync();
            return Ok(addUser);
        }


        [HttpPatch("EditUser/{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDTO updateContact)
        {
            var contact = await _context.Users.FindAsync(id);

            if (contact != null)
            {
                contact.Name = updateContact.Name;
                contact.Surname = updateContact.Surname;
                contact.Email = updateContact.Email;

                await _context.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpGet("GetAUser/{id}")]
        public async Task<IActionResult> GetContact(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) { return NotFound(); }

            return Ok(user);

        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DelectUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(UserLoginDTO loginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);

            if (user == null) { return BadRequest("Invald Crendentials"); }

            if (loginDTO.Email == null) { return BadRequest("Invald Crendentials"); }

            bool test = user.PassVali(loginDTO.Password);

            if (test) { return Ok(user); }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }

        [HttpGet("GetUserInfo/{id}")]
        public async Task<IActionResult> GetUserAndEntries(Guid id)
        {
            var details = await _context.Users.Include(x => x.SessionDetails).FirstOrDefaultAsync(x => x.Id == id);
            if (details == null) { return NotFound(); }
            return Ok(details);
        }
    }
}
