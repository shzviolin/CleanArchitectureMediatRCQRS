using Application.Queries.EmployeeQuery;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Infrastructure.Handlers.EmployeeHandler
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly ApplicationDbContext _appDbContext;

        public GetEmployeeByIdHandler(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            => await _appDbContext.Employees.FindAsync(request.Id);
    }
}
