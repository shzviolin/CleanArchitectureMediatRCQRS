using Application.DTOs;
using MediatR;

namespace Application.Commands.EmployeeCommand
{
    public class DeleteEmployeeByIdCommand:IRequest<ServiceResponse>
    {
        public int Id { get; set; }
    }
}
