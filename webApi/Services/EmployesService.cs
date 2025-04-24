using webApi.Models;
using webApi.Models.Dtos;
using webApi.Repositories.Interfaces;
using webApi.Services.Interfaces;

namespace webApi.Services
{
    public class EmployesService:IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        public EmployesService(IEmployeesRepository _employeesRepository) {
            this._employeesRepository = _employeesRepository;
        }

        public async Task<ICollection<EmployeeDto>> GetEmployesSync()
        {
            try
            {
                ICollection<Employee> employees = await _employeesRepository.GetEmployeesAsync();
                return employees.Select(o => new EmployeeDto
                {
                    Empid = o.Empid,
                    FullName = o.Firstname + " " + o.Lastname
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error processing order", ex);
            }
        }
    }
}
