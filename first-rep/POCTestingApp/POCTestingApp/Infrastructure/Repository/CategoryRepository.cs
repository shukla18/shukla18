using Microsoft.Extensions.Configuration;
using POCTestingApp.Core.Entities;
using POCTestingApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;

namespace POCTestingApp.Infrastructure.Repository
{
    internal class ICategoryRepository : Core.Interfaces.ICategoryRepository
    {
        private readonly IConfiguration configuration;



        public ICategoryRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> FindAll()
        {
            dynamic returnData;

            using (var connection = new SQLiteConnection(configuration.GetConnectionString("SqLiteConnection")))
            {
                var sql = "select * from category";
                var categories = connection.Query(sql);
                foreach (var customer in categories)
                {
                    Console.WriteLine($"{customer.CustomerID} {customer.CompanyName}");
                }
                Console.ReadLine();

                returnData = categories;
            }

                return returnData;
        }

        public Task<IEnumerable<Category>> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
