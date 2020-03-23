using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExpenses.Common.Models;
using TravelExpenses.Web.Data;
using TravelExpenses.Web.Data.Entities;
using TravelExpenses.Web.Helpers;

namespace TravelExpenses.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly DataContext _context; 
        private readonly IConverterHelper _converterHelper;

        public TravelsController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        // GET: api/Travels
        /*[HttpGet]
        public IEnumerable<TravelEntity> GetTravels()
        {
            return _context.Travels;
        }*/

        // GET: api/Travels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTravelEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TravelEntity travelEntity = await _context.Travels
                .Include(t => t.User)
                .Include(t => t.Expenses)
                    .ThenInclude(t => t.ExpenseType)
                .FirstOrDefaultAsync(t => t.Id == id);

            /*List<TravelEntity> result = _context.Travels
                .Where(t => t.City == "Massachusets")
                .Include(t => t.User)
                .Include(t => t.Expenses)
                .ThenInclude(t => t.ExpenseType)
                .ToList<TravelEntity>();

            List<TravelResponse> list2 = new List<TravelResponse>();
            foreach (TravelEntity element in result){
                list2.Add(_converterHelper.ToTravelResponse(element));
            }

            //return Ok(list2);*/
            
            if (travelEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToTravelResponse(travelEntity));
        }

        // PUT: api/Travels/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutTravelEntity([FromRoute] int id, [FromBody] TravelEntity travelEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travelEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Travels
        [HttpPost]
        public async Task<IActionResult> PostTravelEntity([FromBody] TravelEntity travelEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Travels.Add(travelEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelEntity", new { id = travelEntity.Id }, travelEntity);
        }

        // DELETE: api/Travels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var travelEntity = await _context.Travels.FindAsync(id);
            if (travelEntity == null)
            {
                return NotFound();
            }

            _context.Travels.Remove(travelEntity);
            await _context.SaveChangesAsync();

            return Ok(travelEntity);
        }

        private bool TravelEntityExists(int id)
        {
            return _context.Travels.Any(e => e.Id == id);
        }*/
    }
}