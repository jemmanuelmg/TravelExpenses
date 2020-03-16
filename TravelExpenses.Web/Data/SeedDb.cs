using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpenses.Web.Data.Entities;

namespace TravelExpenses.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTravelsAsync();
        }

        private async Task CheckTravelsAsync()
        {
            if (!_dataContext.Travels.Any())
            {
                _dataContext.Travels.Add(new TravelEntity
                {
                    Id = 100,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3),
                    City = "Medellin",
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Id = 200,
                            Value = 350000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 201,
                            Value = 200000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 202,
                            Value = 150000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    Id = 101,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    City = "Bogota",
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Id = 203,
                            Value = 450000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 204,
                            Value = 300000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 205,
                            Value = 250000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    Id = 102,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    City = "Barranquilla",
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Id = 203,
                            Value = 150000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 204,
                            Value = 500000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 205,
                            Value = 200000,
                            Category = "Alimentacion",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                    }
                });

                _dataContext.Travels.Add(new TravelEntity
                {
                    Id = 103,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(15),
                    City = "Bucaramanga",
                    Expenses = new List<ExpenseEntity>
                    {
                        new ExpenseEntity
                        {
                            Id = 203,
                            Value = 120000,
                            Category = "Transporte",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 204,
                            Value = 800000,
                            Category = "Hospedaje",
                            CreatedDate = DateTime.UtcNow,
                            ReceiptPath = "test/route/to/receipt.jpg"
                        },
                        new ExpenseEntity
                        {
                            Id = 205,
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
