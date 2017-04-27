using GradeSystem.Data.Repositories;
using GradeSystem.Model;
using System;
using System.Collections.Generic;

namespace GradeSystem.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        public IEnumerable<Student> GetAllStudents(string name)
        {
            return _studentRepository.GetAll();
        }
        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _studentRepository.Save();
        }

        public Student GetStudent(int? id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(string name)
        {
            throw new NotImplementedException();
        }
    }
}