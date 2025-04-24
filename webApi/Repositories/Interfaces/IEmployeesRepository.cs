using webApi.Models;
using webApi.Models.Dtos;

namespace webApi.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<ICollection<Employee>> GetEmployeesAsync();
    }
}
