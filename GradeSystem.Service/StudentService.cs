using GradeSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeSystem.Model;

namespace GradeSystem.Service
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository _istudentRepository;

        public StudentService(IStudentRepository istudentRepository)
        {
            _istudentRepository = istudentRepository;
        }

        void IStudentService.CreateStudent(Student student)
        {
            _istudentRepository.Add(student);
        }

        void IStudentService.DeleteStudent(Student student)
        {
            _istudentRepository.Delete(student);
        }

        IEnumerable<Student> IStudentService.GetAllStudents(string name)
        {
            return _istudentRepository.GetAll();
        }

        Student IStudentService.GetStudent(string name)
        {
           return _istudentRepository.GetByName(name);
        }

        Student IStudentService.GetStudent(int? id)
        {
            return _istudentRepository.GetById(id);
        }

        void IStudentService.UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
