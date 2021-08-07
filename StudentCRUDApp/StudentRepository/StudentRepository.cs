using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Students.Model;

namespace StudentsRepository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> _students;
        private static StudentRepository _instance = null;
        public StudentRepository()
        {
            _students = new List<Student>();
            _students.Add(new Student(10, "omkar", 7.9));
            _students.Add(new Student(11, "sagar", 8.9));
            _students.Add(new Student(12, "sachin", 7.2));
            _students.Add(new Student(13, "rahul", 6.9));
            _students.Add(new Student(14, "pradeep", 9.1));
            Debug.WriteLine("Student Created");
        }

        public static StudentRepository GetInstance()
        {
            if(_instance == null)
            {
                _instance = new StudentRepository();
            }
            return _instance;
        }

        public List<Student> Get()
        {
            return _students;
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public Student GetStudent(Guid id)
        {
            foreach (Student student in _students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
    }
}
