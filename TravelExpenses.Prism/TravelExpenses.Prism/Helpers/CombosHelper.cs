using System;
using System.Collections.Generic;
using System.Text;
using TravelExpenses.Common.Models;

namespace TravelExpenses.Prism.Helpers
{
    public static class CombosHelper
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { Id = 0, Name = "Administrador" },
                new Role { Id = 1, Name = "Usuario" }
            };
        }

        public static List<ExpenseCategory> GetExpenseCategories()
        {
            return new List<ExpenseCategory>
            {
                new ExpenseCategory { Id = 1, Name = "Transporte" },
                new ExpenseCategory { Id = 2, Name = "Hospedaje" },
                new ExpenseCategory { Id = 3, Name = "Alimentación" }
            };
        }

    }
}
