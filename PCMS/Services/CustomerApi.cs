using System;
using System.Threading.Tasks;
using PCMS.Data;
using PCMS.Interfaces;

namespace PCMS.Services
{
    public class CustomerApi : ICustomerApi
    {
        private readonly PhotoCmsContext _db;

        public CustomerApi(PhotoCmsContext db)
        {
            _db = db;
        }

        public async Task<string> SearchCustomerByName(string name)
        {
            try
            {
                // Assume you have a DbSet<Customer> in your PhotoCmsContext
                var customers = _db.Customers.Where(c => c.CustomerName == name).ToList();
                // Convert the list of customers to a string representation, for example using JSON serialization
                string result = Newtonsoft.Json.JsonConvert.SerializeObject(customers);
                return result;
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}