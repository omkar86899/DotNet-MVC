using System;

namespace Students.Model
{
    public class Student
    {
        private Guid _id;
        private int _rollNo;
        private String _name;
        private double _cgpa;

        public Student(int rollNo, String name, double cgpa)
        {
            _id = Guid.NewGuid();
            _rollNo = rollNo;
            _name = name;
            _cgpa = cgpa;
        }

        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public int RollNo
        {
            get
            {
                return _rollNo;
            }
        }

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public double Cgpa
        {
            get
            {
                return _cgpa;
            }
        }
    }
}
