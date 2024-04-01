using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Commands.EmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<ServiceResponse>
    {
        public Employee? Employee { get; set; }
    }
}
