using EMS.Core.Business.Interfaces;
using EMS.Core.Models;

namespace EMS.Core.Business.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateEmployee()
        {
            try
            {
                _context.Employees.Add(new Employee
                {

                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
