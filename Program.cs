using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectValueFromNestedList
{
    public class Program
    {
        public static void Main()
        {
            School school = new School()
            {
                Classes = new List<SchoolClass>()
        {
            new SchoolClass(){ClassID = 1, ClassName="A", Students = new List<Student>()
                {
                    new Student(){StuID = 1, Name="Maciej", ColorOfSocks="yellow"},
                    new Student(){StuID = 5, Name="Anna", ColorOfSocks="red"},
                    new Student(){StuID = 22, Name="Robert", ColorOfSocks="green"}
                }},
            new SchoolClass(){ClassID = 2, ClassName="B", Students = null
                //{
                //Student
                //    //new Student(){StuID = 2, Name="Fred", ColorOfSocks="black"},
                //    //new Student(){StuID = 3, Name="Viana", ColorOfSocks="gray"},
                //    //new Student(){StuID = 21, Name=null, ColorOfSocks="red"}
                //}
            }
        }
            };

            var cla = school.Classes.Where(c => c.Students.Any(s => s.ColorOfSocks == "red"));
            //returns the list of all existing classes, because in each class there's at least one studnet with red socks!
            Console.WriteLine(cla);

            var stu = school.Classes.Select(c => c.Students.Where(s => s.ColorOfSocks == "red"));
            //returns the list of students which meets the criteria: {color of socks = red}
            Console.WriteLine(stu);
            if (school.Classes !=null && school.Classes.Any())
            {
                var classs = school.Classes.Where(c => c.ClassID == 2).ToList();// Where(X => X.Students.Any(s => s.ColorOfSocks == "red")).FirstOrDefault().Students.FirstOrDefault().Name;
                if (classs != null && classs.Any())
                {
                    var NAME1 = classs.Where(X => X.Students !=null && X.Students.Any() && X.Students.Any(s => !string.IsNullOrEmpty(s.ColorOfSocks) && s.ColorOfSocks.ToUpper().Contains("RED"))); //FirstOrDefault().Students.FirstOrDefault().Name;
                    if (NAME1 !=null && NAME1.Any())
                    {
                        var final = NAME1.FirstOrDefault().Students.Where(p => !string.IsNullOrEmpty(p.ColorOfSocks) && p.ColorOfSocks.ToUpper().Contains("RED"));
                        if (final !=null && final.Any())
                        {
                            var finalname = final.FirstOrDefault().Name;
                        }
                        Console.WriteLine(final);
                    }
                }
            }
            //.Where(P=>P.Students.Any(s => s.ColorOfSocks == "red")).Select(x=>x.NA;
        }
        public class School
        {
            public List<SchoolClass> Classes = new List<SchoolClass>();
        }

        public class SchoolClass
        {
            public int ClassID { get; set; }
            public string ClassName { get; set; }
            public List<Student> Students = new List<Student>();
        }

        public class Student
        {
            public int StuID { get; set; }
            public string Name { get; set; }
            public string ColorOfSocks { get; set; }

        }
    }

}
