using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Common.Models;
using TravelExpenses.Web.Data.Entities;

namespace TravelExpenses.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public TravelResponse ToTravelResponse(TravelEntity travelEntity)
        {
            return new TravelResponse
            {
                Id = travelEntity.Id,
                StartDate = travelEntity.StartDate,
                EndDate = travelEntity.EndDate,
                City = travelEntity.City,
                User = ToUserResponse(travelEntity.User),
                Expenses = travelEntity.Expenses?.Select(e => new ExpenseResponse
                {
                    Id = e.Id,
                    Value = e.Value,
                    CreatedDate = e.CreatedDate,
                    ReceiptPath = e.ReceiptPath,
                    Comment = e.Comment,
                    ExpenseType = ToExpenseTypeResponse(e.ExpenseType)

                }).ToList(),
            };
        }

        public UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Id = user.Id,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };
        }

        public ExpenseResponse ToExpenseResponse(ExpenseEntity expenseEntity)
        {
            return new ExpenseResponse
            {
                Id = expenseEntity.Id,
                Value = expenseEntity.Value,
                CreatedDate = expenseEntity.CreatedDate,
                ReceiptPath = expenseEntity.ReceiptPath,
                ExpenseType = ToExpenseTypeResponse(expenseEntity.ExpenseType)
            };
        }


        public ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expenseType)
        {
            if (expenseType == null)
            {
                return null;
            }

            return new ExpenseTypeResponse
            {
                Id = expenseType.Id, 
                Name = expenseType.Name
            };
        }

    }
}
