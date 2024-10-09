using CQRSDemo.Commands;
using CQRSDemo.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSDemo.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _repository;
        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _repository = studentRepository;
        }
        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteStudentAsync(request.Id);
        }
    }
}
