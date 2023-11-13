using Microsoft.EntityFrameworkCore;
using PCMS.Data;
using PCMS.Interfaces;
using PCMS.Models;

namespace PCMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly PhotoCmsContext _db;
        public EmployeeService(PhotoCmsContext db)
        {
            _db = db;
        }
        public Customers AddEmployee(Customers employee)
        {
            var emp = _db.Customers.Add(employee);
            _db.SaveChanges();
            return emp.Entity;
        }

        public List<Customers> GetEmployeeDetails()
        {
            var employees = _db.Customers.ToList();
            return employees;
        }
    }
}
