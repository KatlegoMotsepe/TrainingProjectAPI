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
    public class EntriesController : ControllerBase
    {
        private readonly DataContext context;

        public EntriesController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("Entries/{id}")]
        public async Task<IActionResult> GetEntries(Guid id) 
        {
            var entry = await context.Entries.Include(x=>x.SessionDetails).SingleOrDefaultAsync();
            if (entry == null) { return NotFound();}
            return Ok(entry);
        }

        [HttpPost("Add")] //Over explaining is a thing.
        public async Task<IActionResult> AddEntry(AddEntryDTO addEntryDTO)
        {
            if (addEntryDTO == null) { return BadRequest("You can't enter nothing"); }
            await context.Entries.AddAsync(new Entries(addEntryDTO));
            await context.SaveChangesAsync();
            return Ok(addEntryDTO);
        }
    }
}
