using CQRSDemo.Database;
using CQRSDemo.Interfaces;
using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentServiceContext _studentDbContext;
        public StudentRepository(StudentServiceContext studentServiceContext)
        {
            _studentDbContext = studentServiceContext ?? throw new ArgumentNullException(nameof(studentServiceContext));    
        }

        public async Task<Student> AddStudentAsync(Student studentDetails)
        {
            var result = _studentDbContext.Students.Add(studentDetails);
            await _studentDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(int Id)
        {
            var record = _studentDbContext.Students.Where(s => s.Id == Id).FirstOrDefault();
            if ( record == null)
            {
                return 0;
            }
            _studentDbContext.Students.Remove(record);
            return await _studentDbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            return _studentDbContext.Students.Where(s => s.Id == Id).FirstOrDefault();
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(Student studentDetails)
        {
            var record = _studentDbContext.Students.Where(s => s.Id == studentDetails.Id);

            if (record.Any())
            {
                var result = _studentDbContext.Students.Update(studentDetails);
                return await _studentDbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}
