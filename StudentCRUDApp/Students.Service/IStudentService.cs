using Students.Model;
using System;
using System.Collections.Generic;

namespace Students.Service
{
    public interface IStudentService
    {
        void Add(Student student);
        int Count();
        List<Student> Get();
        Student GetStudent(Guid id);
    }
}