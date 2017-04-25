using GradeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeSystem.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly SystemContext _context;
        public StudentRepository(SystemContext context) : base(context)
        {
            _context = context;
        }

        public Student GetById(int? id)
        {
            return FindBy(x => x.ID == id).FirstOrDefault();
        }

        public Student GetByName(string name)
        {
            return FindBy(x => x.LastName == name).FirstOrDefault();
        }
    }
}
