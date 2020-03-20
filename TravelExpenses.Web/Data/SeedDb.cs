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

            await CheckTravelsAsync(admin, user1, user2);
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


        private async Task CheckTravelsAsync(UserEntity driver, UserEntity user1, UserEntity user2)

        {
            if (!_dataContext.Travels.Any())
            {
                _dataContext.Travels.Add(new TravelEntity
                {
                    //id = 100,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    City = "Medellin",
                    User = user1,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            //id = 200,
                            Value = 350000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 201,
                            Value = 200000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 202,
                            Value = 150000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    //id = 101,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    City = "Bogota",
                    User = user1,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            //id = 203,
                            Value = 450000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 204,
                            Value = 300000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 205,
                            Value = 250000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    //id = 102,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    City = "Barranquilla",
                    User = user2,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            //id = 206,
                            Value = 150000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 207,
                            Value = 500000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 208,
                            Value = 200000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    //id = 103,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(15),
                    City = "Bucaramanga",
                    User = user2,
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            //id = 209,
                            Value = 120000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 210,
                            Value = 800000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            //id = 211,
                            Value = 200000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
