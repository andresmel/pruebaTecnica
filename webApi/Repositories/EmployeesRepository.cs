using Microsoft.EntityFrameworkCore;
using webApi.Models;
using webApi.Repositories.Interfaces;
using webApi.StoreSampleContext;

namespace webApi.Repositories
{
    public class EmployeesRepository:IEmployeesRepository
    {
        private readonly StoreSampleContext.StoreSampleContext _storeSampleContext;
        public EmployeesRepository(StoreSampleContext.StoreSampleContext _storeSampleContext) {
           this._storeSampleContext = _storeSampleContext;
        }

        public async Task<ICollection<Employee>> GetEmployeesAsync()
        {  
            return await this._storeSampleContext.Employees.ToListAsync();
        }
    }
}
