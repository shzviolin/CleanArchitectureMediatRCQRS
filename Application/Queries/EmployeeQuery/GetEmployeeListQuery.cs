using Domain.Entities;
using MediatR;


namespace Application.Queries.EmployeeQuery
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
