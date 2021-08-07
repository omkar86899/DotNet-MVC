using Students.Model;
using System;
using System.Collections.Generic;

namespace StudentsRepository
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<Student> Get();
        Student GetStudent(Guid id);
    }
}