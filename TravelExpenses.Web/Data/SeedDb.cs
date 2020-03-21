using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Common.Enums;
using TravelExpenses.Web.Data.Entities;
using TravelExpenses.Web.Helpers;

namespace TravelExpenses.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;

        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();

            var admin = await CheckUserAsync("1010", "Emmanuel", "Martinez", "3182024296", "jemmanuelmg@hotmail.com", UserType.Admin);
            var user1 = await CheckUserAsync("3030", "Maria", "Arenas", "3182024296", "maria_arenas_travelexpenses@yopmail.com", UserType.User);
            var user2 = await CheckUserAsync("4040", "Carlos", "Restrepo", "3182024296", "carlos_restrepo_travelexpenses@yopmail.co", UserType.User);

            var expenseType1 = await CheckExpenseTypeAsync("Transporte");
            var expenseType2 = await CheckExpenseTypeAsync("Hospedaje");
            var expenseType3 = await CheckExpenseTypeAsync("Alimentacion");

            await CheckTravelsAsync(admin, user1, user2, expenseType1, expenseType2, expenseType3);
        }

        private async Task<UserEntity> CheckUserAsync(string document, string firstName, string lastName, string phone, string email, UserType userType)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }


        private async Task<ExpenseTypeEntity> CheckExpenseTypeAsync(string name)
        {
            ExpenseTypeEntity expenseType = new ExpenseTypeEntity();
            expenseType.Name = name;
            _dataContext.Add(expenseType);
            await _dataContext.SaveChangesAsync();

            return expenseType;

        }


        private async Task CheckTravelsAsync(UserEntity driver, UserEntity user1, UserEntity user2, ExpenseTypeEntity expenseType1, ExpenseTypeEntity expenseType2, ExpenseTypeEntity expenseType3)
        {
            if (!_dataContext.Travels.Any())
            {
                _dataContext.Travels.Add(new TravelEntity
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    City = "Medellin",
                    User = user1,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Value = 350000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType1
                        },
                        new ExpenseEntity
                        {
                            Value = 200000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType2
                        },
                        new ExpenseEntity
                        {
                            Value = 150000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType3
                        },
                    }
                }) ;

                _dataContext.Travels.Add(new TravelEntity
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    City = "Bogota",
                    User = user1,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Value = 450000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType1
                        },
                        new ExpenseEntity
                        {
                            Value = 300000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType2
                        },
                        new ExpenseEntity
                        {
                            Value = 250000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType3
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    City = "Barranquilla",
                    User = user2,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Value = 150000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType1
                        },
                        new ExpenseEntity
                        {
                            Value = 500000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType2
                        },
                        new ExpenseEntity
                        {
                            Value = 200000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType3
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(15),
                    City = "Bucaramanga",
                    User = user2,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Value = 120000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType1
                        },
                        new ExpenseEntity
                        {
                            Value = 800000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType2
                        },
                        new ExpenseEntity
                        {
                            Value = 200000,
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg",
                            ExpenseType = expenseType3
                        },
                    }
                });

                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
