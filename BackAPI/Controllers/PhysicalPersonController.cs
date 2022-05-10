using Microsoft.AspNetCore.Mvc;
using BackAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace BackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalPersonController : Controller
    {
        private readonly PcShopContext db;

        public PhysicalPersonController(PcShopContext pcShopContext)
        {
            db = pcShopContext;
        }

        [HttpGet]
        public IEnumerable<PhysicalPerson> GetAll()
        {
            return db.PhysicalPerson;
        }

        [HttpGet("{physical_person_id}")]
        public async Task<IActionResult> GetLegalPerson([FromRoute] int physical_person_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var physicalPersons = await db.PhysicalPerson.SingleOrDefaultAsync(c => c.physical_person_id == physical_person_id);

            if (physicalPersons == null)
            {
                return NotFound();
            }
            return Ok(physicalPersons);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateLegalPerson([FromBody] PhysicalPerson physicalPersons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // legalPersons.legal_person_id = db.LegalPerson.Last().legal_person_id + 1;
            db.PhysicalPerson.Add(physicalPersons);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetProducts", new { physical_person_id = physicalPersons.physical_person_id }, physicalPersons);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{physical_person_id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int physical_person_id, [FromBody] PhysicalPerson physicalPersons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.PhysicalPerson.Find(physical_person_id);

            if (item == null)
            {
                return NotFound();
            }

            item.physical_person_name = physicalPersons.physical_person_name;
            item.physical_person_pasport_number = physicalPersons.physical_person_pasport_number;
            item.physical_person_TIN = physicalPersons.physical_person_TIN;

            db.PhysicalPerson.Update(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{physical_person_id}")]
        public async Task<IActionResult> DeleteDeposit([FromRoute] int physical_person_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.PhysicalPerson.Find(physical_person_id);

            if (item == null)
            {
                return NotFound();
            }

            db.PhysicalPerson.Remove(item);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
