using PCMS.Models;

namespace PCMS.Interfaces
{
    public interface IEmployeeService
    {
        public List<Customers> GetEmployeeDetails();
        public Customers AddEmployee(Customers employee);
    }
}
