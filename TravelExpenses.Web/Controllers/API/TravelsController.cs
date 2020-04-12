using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Common.Models;
using TravelExpenses.Web.Data;
using TravelExpenses.Web.Data.Entities;
using TravelExpenses.Web.Helpers;

namespace TravelExpenses.Web.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public TravelsController(DataContext context, IUserHelper userHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }



        // POST: api/Travels
        [HttpPost]
        public async Task<IActionResult> PostTravelEntity([FromBody] TravelRequest travelRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserEntity userEntity = await _userHelper.GetUserAsync(travelRequest.UserId);
            if (userEntity == null)
            {
                return BadRequest("User doesn't exists.");
            }

            TravelEntity travelEntity = new TravelEntity 
            { 
                StartDate = travelRequest.StartDate,
                EndDate = travelRequest.EndDate,
                City = travelRequest.City,
                User = userEntity
            };

            _context.Travels.Add(travelEntity);
            await _context.SaveChangesAsync();

            return Ok(_converterHelper.ToTravelResponse(travelEntity)); ;
        }

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

            if (travelEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToTravelResponse(travelEntity));
        }

        [HttpPost]
        [Route("GetMyTravels")]
        public async Task<IActionResult> GetMyTrips([FromBody] MyTravelsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var travelEntities = await _context.Travels
                .Where(t => t.User.Id == request.UserId)
                .Include(t => t.User)
                .Include(t => t.Expenses)
                .ThenInclude(t => t.ExpenseType)
                .OrderByDescending(t => t.StartDate)
                .ToListAsync();

            List<TravelResponse> travelsList = new List<TravelResponse>();
            foreach (TravelEntity element in travelEntities)
            {
                travelsList.Add(_converterHelper.ToTravelResponse(element));
            }

            return Ok(travelsList);
        }

        // GET: api/Travels
        /*[HttpGet]
        public IEnumerable<TravelEntity> GetTravels()
        {
            return _context.Travels;
        }*/

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