using Students.Model;
using StudentsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Service
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repo;

        public StudentService()
        {
            _repo = StudentRepository.GetInstance();
        }

        public List<Student> Get()
        {
            return _repo.Get();
        }

        public void Add(Student student)
        {
            if (AllFieldsValid(student))
            {
                _repo.Add(student);
                return;
            }
            throw new Exception("Data is Not Valid");
        }

        private bool AllFieldsValid(Student student)
        {
            if (student.Name.Length < 0 || student.Id == Guid.Empty || student.RollNo < 1 || student.Cgpa < 1)
            {
                return false;
            }
            return true;
        }

        public int Count()
        {
            return _repo.Get().Count;
        }

        public Student GetStudent(Guid id)
        {
            return _repo.GetStudent(id);
        }
    }
}
