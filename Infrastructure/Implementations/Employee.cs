using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Implementations
{
    public class Employee : IEmployee
    {
        private readonly ApplicationDbContext _appDbContext;

        public Employee(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> AddAsync(Domain.Entities.Employee employee)
        {
            var check = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Name.ToLower() == employee.Name.ToLower());
            if (check != null)
                return new ServiceResponse(false, "User already exist");
            await _appDbContext.Employees.AddAsync(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
                return new ServiceResponse(false, "User not found");

            _appDbContext.Employees.Remove(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Domain.Entities.Employee>> GetAsync() => await _appDbContext.Employees.AsNoTracking().ToListAsync();

        public async Task<Domain.Entities.Employee> GetByIdAsync(int id) => await _appDbContext.Employees.FindAsync(id);

        public async Task<ServiceResponse> UpdateAsync(Domain.Entities.Employee employee)
        {
            _appDbContext.Employees.Update(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }


        private async Task SaveChangesAsync() => await _appDbContext.SaveChangesAsync();
    }
}
