using Application.Commands.EmployeeCommand;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeeHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, ServiceResponse>
    {
        private readonly ApplicationDbContext _appDbContext;

        public CreateEmployeeHandler(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var check = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Name.ToLower() == request.Employee.Name.ToLower());
            if (check != null)
                return new ServiceResponse(false, "User already exist");
            await _appDbContext.Employees.AddAsync(request.Employee);
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }
    }
}
