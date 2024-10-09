using CQRSDemo.Commands;
using CQRSDemo.Interfaces;
using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        IStudentRepository _studentRepository;
        public AddStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        public async Task<Student> Handle(AddStudentCommand command, CancellationToken cancellationToken)
        {
            Student s = new Student()
            {
                StudentAge = command.StudentAge,
                StudentAddress = command.StudentAddress,
                StudentEmail = command.StudentEmail,
                StudentName = command.StudentName
            };
            return await _studentRepository.AddStudentAsync(s);
        }
    }
}
