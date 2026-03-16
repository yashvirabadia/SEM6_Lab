using EventRegistrationAPI.Data;
using EventRegistrationAPI.DTO;
using EventRegistrationAPI.Models;
using EventRegistrationAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;

        public RegistrationsController(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var data = await _context.Registrations.ToListAsync();
            return Ok(data);
        }

        // POST: api/Registrations (Create with file)
        [HttpPost]
        public async Task<IActionResult> CreateRegistration([FromForm] RegistrationCreateUpdateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? filePath = null;

            if (model.DocumentFile != null)
            {
                filePath = await _fileService.UploadFileAsync(model.DocumentFile, "registrations");
            }

            var reg = new Registration
            {
                ParticipantName = model.ParticipantName,
                Email = model.Email,
                EventName = model.EventName,
                Age = model.Age,
                RegistrationDate = DateTime.Now,
                DocumentPath = filePath
            };

            await _context.Registrations.AddAsync(reg);
            await _context.SaveChangesAsync();

            return Ok(reg);
        }

        // PUT: api/Registrations/5 (Update + replace file)
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRegistration(int id, [FromForm] RegistrationCreateUpdateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _context.Registrations.FindAsync(id);
            if (existing == null)
                return NotFound();

            // Replace file if new one is sent
            if (model.DocumentFile != null && model.DocumentFile.Length > 0)
            {
                _fileService.DeleteFile(existing.DocumentPath);
                existing.DocumentPath = await _fileService.UploadFileAsync(model.DocumentFile, "registrations");
            }

            existing.ParticipantName = model.ParticipantName;
            existing.Email = model.Email;
            existing.EventName = model.EventName;
            existing.Age = model.Age;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Registrations/5 (Delete file too)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var reg = await _context.Registrations.FindAsync(id);
            if (reg == null)
                return NotFound();

            _fileService.DeleteFile(reg.DocumentPath);

            _context.Registrations.Remove(reg);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
