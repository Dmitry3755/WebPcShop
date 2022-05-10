using Microsoft.AspNetCore.Http;
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
    public class LegalPersonController : Controller
    {
        private readonly PcShopContext db;

        public LegalPersonController(PcShopContext pcShopContext)
        {
            db = pcShopContext;
        }

        [HttpGet]
        public IEnumerable<LegalPerson> GetAll()
        {
            return db.LegalPerson;
        }

        [HttpGet("{legal_person_id}")]
        public async Task<IActionResult> GetLegalPerson([FromRoute] int legal_person_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var legalPersons = await db.LegalPerson.SingleOrDefaultAsync(c => c.legal_person_id == legal_person_id);

            if (legalPersons == null)
            {
                return NotFound();
            }
            return Ok(legalPersons);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateLegalPerson([FromBody] LegalPerson legalPersons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // legalPersons.legal_person_id = db.LegalPerson.Last().legal_person_id + 1;
            db.LegalPerson.Add(legalPersons);
            await db.SaveChangesAsync();
            return CreatedAtAction("GetProducts", new { legal_person_id = legalPersons.legal_person_id }, legalPersons);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{legal_person_id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int legal_person_id, [FromBody] LegalPerson legalPersons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.LegalPerson.Find(legal_person_id);

            if (item == null)
            {
                return NotFound();
            }

            item.Legal_person_TIN = legalPersons.Legal_person_TIN;
            item.Legal_person_CRS = legalPersons.Legal_person_CRS;
            item.Legal_person_MSRN = legalPersons.Legal_person_MSRN;

            db.LegalPerson.Update(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{legal_person_id}")]
        public async Task<IActionResult> DeleteDeposit([FromRoute] int legal_person_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = db.LegalPerson.Find(legal_person_id);

            if (item == null)
            {
                return NotFound();
            }

            db.LegalPerson.Remove(item);
            await db.SaveChangesAsync();
            return NoContent();
        }

    }
}
