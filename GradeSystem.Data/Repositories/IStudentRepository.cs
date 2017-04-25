
using GradeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeSystem.Data.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetById(int? id);

        Student GetByName(string name);
    }
}
