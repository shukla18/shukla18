using CQRSDemo.Models;
using MediatR;
namespace CQRSDemo.Commands
{
    public class AddStudentCommand : IRequest<Student>
    {
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }

        //public AddStudentCommand(string name, string email, int age, string address)
        //{
        //    this.StudentName = name;
        //    this.StudentEmail = email;
        //    this.StudentAddress = address;
        //    this.StudentAge = age;
        //}
    }
}
