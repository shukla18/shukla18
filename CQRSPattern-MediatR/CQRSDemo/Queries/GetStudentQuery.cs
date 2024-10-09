using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Queries
{
    public class GetStudentQuery: IRequest<Student>
    {
        public int Id { get; set; }
    }
}
