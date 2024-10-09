using CQRSDemo.Commands;
using CQRSDemo.Interfaces;
using CQRSDemo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSDemo.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _repository;
        public UpdateStudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                Id = request.Id,
                StudentAddress = request.StudentAddress,
                StudentAge = request.StudentAge,
                StudentEmail = request.StudentEmail,
                StudentName = request.StudentName
            };

            return await _repository.UpdateStudentAsync(student);
        }
    }
}
