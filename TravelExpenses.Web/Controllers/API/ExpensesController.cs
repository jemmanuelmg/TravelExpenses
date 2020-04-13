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
    public class ExpensesController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly IMailHelper _mailHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public ExpensesController(DataContext dataContext, IUserHelper userHelper, IMailHelper mailHelper, IImageHelper imageHelper, IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _mailHelper = mailHelper;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        public async Task<IActionResult> PostExpense([FromBody] ExpenseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new Response
                {
                    IsSuccess = false,
                    Message = "Bad request",
                    Result = ModelState
                });
            }

            string receiptPath = string.Empty;
            if (request.PictureArray != null && request.PictureArray.Length > 0)
            {
                receiptPath = _imageHelper.UploadImage(request.PictureArray, "Receipts");
            }

            //Obyener el viaje con id request.travelId x
            //Obtener el expense type con id request.xxpenseTypeId x
            List<TravelEntity> auxTravelList = await _dataContext.Travels.Where(t => t.Id == request.TravelId).ToListAsync();
            List<ExpenseTypeEntity> auxExpenseTypeList = await _dataContext.ExpenseTypes.Where(e => e.Id == request.ExpenseTypeId).ToListAsync();

            ExpenseEntity expenseEntity = new ExpenseEntity
            {
                Value = request.Value,
                Comment = request.Comment,
                Travel = auxTravelList[0],
                ExpenseType = auxExpenseTypeList[0],
                ReceiptPath = receiptPath
            };

            _dataContext.Expenses.Add(expenseEntity);
            await _dataContext.SaveChangesAsync();

            return Ok(new Response
            {
                IsSuccess = true,
                Message = "Gasto guardado existosamente."
            });
        }

    }
}
