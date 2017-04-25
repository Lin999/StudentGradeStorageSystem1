using GradeSystem.Data.Repositories;
using GradeSystem.Model;
using System;
using System.Collections.Generic;

namespace GradeSystem.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _istudentRepository;

        public StudentService(IStudentRepository istudentRepository)
        {
            _istudentRepository = istudentRepository;
        }

        public void CreateStudent(Student student)
        {
            _istudentRepository.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _istudentRepository.Delete(student);
        }

        public IEnumerable<Student> GetAllStudents(string name)
        {
            return _istudentRepository.GetAll();
        }

        public Student GetStudent(string name)
        {
            return _istudentRepository.GetByName(name);
        }

        public Student GetStudent(int? id)
        {
            return _istudentRepository.GetById(id);
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}