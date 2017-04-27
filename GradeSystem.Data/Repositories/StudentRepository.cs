using GradeSystem.Model;
using System.Linq;
using System;

namespace GradeSystem.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {


        public StudentRepository(SystemContext context) : base(context)
        {
       
        }

        public Student GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(d => d.ID == id);
            return student;
        }

        public Student GetStudentByLastName(string lastName)
        {
            var student = _context.Students.FirstOrDefault(s => s.LastName == lastName);
            return student;
        }
    }
}