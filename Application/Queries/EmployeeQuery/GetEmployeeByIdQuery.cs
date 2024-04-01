using Domain.Entities;
using MediatR;


namespace Application.Queries.EmployeeQuery
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
