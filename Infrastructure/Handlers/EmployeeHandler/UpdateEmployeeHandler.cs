using Application.Commands.EmployeeCommand;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.EmployeeHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, ServiceResponse>
    {
        private readonly ApplicationDbContext _appDbContext;

        public UpdateEmployeeHandler(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            _appDbContext.Employees.Update(request.Employee);
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }
    }
}
