using Application.Queries.EmployeeQuery;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Handlers.EmployeeHandler
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly ApplicationDbContext _appDbContext;

        public GetEmployeeListHandler(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
            => await _appDbContext.Employees
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

    }
}
