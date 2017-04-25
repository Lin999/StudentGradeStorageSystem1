using GradeSystem.Model;

namespace GradeSystem.Data.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetById(int? id);

        Student GetByName(string name);
    }
}