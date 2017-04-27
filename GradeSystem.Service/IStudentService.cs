using GradeSystem.Data.Repositories;
using GradeSystem.Model;
using System.Collections.Generic;

namespace GradeSystem.Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents(string name = null);

        Student GetStudent(int id);

        Student GetStudent(string name);

        void CreateStudent(Student student);

        void DeleteStudent(Student student);

        void UpdateStudent(Student student);

        void Save();
    }
}