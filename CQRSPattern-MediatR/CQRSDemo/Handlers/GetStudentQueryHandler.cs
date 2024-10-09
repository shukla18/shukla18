using CQRSDemo.Interfaces;
using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, Student>
    {
        private readonly IStudentRepository _repository;

        public GetStudentQueryHandler(IStudentRepository studentRepository)
        {
            _repository = studentRepository;
        }
        public async Task<Student> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStudentByIdAsync(request.Id);
        }
    }
}
