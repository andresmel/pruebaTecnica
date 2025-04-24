using webApi.Models.Dtos;

namespace webApi.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<ICollection<EmployeeDto>> GetEmployesSync();
    }
}
