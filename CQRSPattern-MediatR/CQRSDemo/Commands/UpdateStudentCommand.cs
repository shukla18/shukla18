using CQRSDemo.Models;
using MediatR;

namespace CQRSDemo.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }
    }
}
