using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTC8440
{
    public class Student
    {

        public Guid Id
        {
            get; //readonly
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public List<string> CourseSignups { get; set; }
        public List<(string Classname, int Grade)> Coursegrades { get; set; }

        public Student(string firstName, string lastname, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Firstname = firstName;
            Lastname = lastname;
            Birthday = birthday;
            Age = DateTime.Now.Year - Birthday.Year;
            CourseSignups = new List<string>();
            Coursegrades = new List<(string Classname, int grade)> { };

        }
        public override string ToString()
        {
            string studentInfo = $"This student's name is {Firstname} {Lastname}, their age is {Age} and their student ID is {Id}";
            if (Coursegrades.Count > 0)
            {
                studentInfo += $" \n{Lastname} has completed the following classes:\n";

                for (int i = 0; i < Coursegrades.Count(); i++)
                {
                    studentInfo += $"The class == {Coursegrades[i].Classname} == Grade: {Coursegrades[i].Grade}\n";
                }

            }
            if (CourseSignups.Count > 0)
            {
                studentInfo += $" \n{Lastname} is currently signed up for the following classes:\n";

                for (int i = 0; i < CourseSignups.Count(); i++)
                {
                    studentInfo += $"The class: {CourseSignups[i]} \n";
                }
            }
            return studentInfo;

        }

        public string SignUpStudentToClass(string course)
        {
            CourseSignups.Add(course);
            return $"The student {Firstname} {Lastname} has been added to {course}";
        }


        public string AddStudentGrade(string course, int grade)
        {
            Coursegrades.Add((course, grade));
            return $"The grade {grade} has been recorded for the class {course} regarding the student {Firstname} {Lastname}.";
        }

    }//Student
    internal class T10Student
    {
        public static void TestT10()
        {
            List<Student> students = new List<Student>();
            string[] firstnames = { "Helene", "Turbo", "Sammy", "Vinny", "Hercules", "Emily", "Matthew" };
            string[] lastnames = { "Schjerfbeck", "Soaker", "Trevor", "Gonzales", "Poirot", "Morgenthal", "Murdock" };
            DateTime[] birthdays = { new DateTime(1989, 2, 2), new DateTime(1989, 9, 9), new DateTime(1989, 2, 2), new DateTime(1999, 8, 21), new DateTime(2005, 7, 7), new DateTime(2002, 4, 30), new DateTime(2000, 4, 3) };
            string[] courses = { "Physics", "Programming 1", "Programming 2", "Physics 2", "Math 1", "English 3", "Spanish 4" };
            for (int i = 0; i < 7; i++)
            {
                Student student = new Student(firstnames[i], lastnames[i], birthdays[i]);
                string add = student.SignUpStudentToClass(courses[i]);
                Console.WriteLine(add);
                students.Add(student);
            }

            string studentAdded = students[3].AddStudentGrade(courses[3], 5);
            string studentAdded2 = students[4].AddStudentGrade(courses[2], 2);
            Console.WriteLine(studentAdded);
            Console.WriteLine(studentAdded2);
            foreach (Student student in students)
            {
                Console.WriteLine(student);

            }
        }
        static void Main(string[] args)
        {

            TestT10();
            Console.ReadKey();

        }//Main
    }
}
