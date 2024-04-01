using Application.Commands.EmployeeCommand;
using Application.DTOs;
using Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Handlers.EmployeeHandler
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, ServiceResponse>
    {
        private readonly ApplicationDbContext _appDbContext;

        public DeleteEmployeeByIdHandler(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ServiceResponse> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var employee = await _appDbContext.Employees.FindAsync(request.Id);
            if (employee == null)
                return new ServiceResponse(false, "User not found");

            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }
    }
}
