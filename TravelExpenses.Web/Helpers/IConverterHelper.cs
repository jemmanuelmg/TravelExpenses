﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Web.Data.Entities;
using TravelExpenses.Common.Models;

namespace TravelExpenses.Web.Helpers
{
    public interface IConverterHelper
    {
        TravelResponse ToTravelResponse(TravelEntity travelEntity);

        ExpenseResponse ToExpenseResponse(ExpenseEntity expenseEntity);

        ExpenseTypeResponse ToExpenseTypeResponse(ExpenseTypeEntity expenseType);

        UserResponse ToUserResponse(UserEntity user);


    }
}
