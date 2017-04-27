using GradeSystem.Model;
using System.Linq;

namespace GradeSystem.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {


        public StudentRepository(SystemContext context) : base(context)
        {
       
        }
        public Student GetStudentByLastName(string lastName)
        {
            var student = _context.Students.FirstOrDefault(s => s.LastName == lastName);
            return student;
        }
    }
}