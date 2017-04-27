using GradeSystem.Model;

namespace GradeSystem.Data.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Student GetStudentByLastName(string lastName);
        Student GetStudentById(int id);
    }
}