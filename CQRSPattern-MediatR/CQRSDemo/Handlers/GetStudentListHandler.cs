using CQRSDemo.Interfaces;
using CQRSDemo.Models;
using CQRSDemo.Queries;
using MediatR;

namespace CQRSDemo.Handlers
{
    public class GetStudentListHandler : IRequestHandler<GetStudentListQuery, IList<Student>>
    {
        private readonly IStudentRepository _repository;
        public GetStudentListHandler(IStudentRepository studentRepository)
        {
            _repository = studentRepository;
        }
        public async Task<IList<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStudentListAsync();
        }
    }
}
