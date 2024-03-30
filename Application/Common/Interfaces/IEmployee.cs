using Application.Common.DTOs;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IEmployee
    {
        Task<ServiceResponse> AddAsync(Employee employee);
        Task<ServiceResponse> UpdateAsync(Employee employee);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
