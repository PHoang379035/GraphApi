using System.Collections.Generic;
using System.Linq;
using GraphApi.Data;
using GraphApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProfilesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Profile> GetProfiles()
        {
            return _dbContext.Profiles.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfile(int id)
        {
            var profile = _dbContext.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        [HttpPost]
        public ActionResult<Profile> CreateProfile(Profile profile)
        {
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, Profile profile)
        {
            var existingProfile = _dbContext.Profiles.Find(id);
            if (existingProfile == null)
            {
                return NotFound();
            }

            existingProfile.Name = profile.Name;
            existingProfile.Email = profile.Email;
            existingProfile.Phone = profile.Phone;

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            var profile = _dbContext.Profiles.Find(id);
            if (profile == null)
            {
                return NotFound();
            }

            _dbContext.Profiles.Remove(profile);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}