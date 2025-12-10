using System.Buffers.Text;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab6_Practice_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var students = new List<Student>
            {
             new Student { Rno = 1, Name = "Amit", Branch = "CE", Sem = 3, CPI = 8, Age = 20 },
             new Student { Rno = 2, Name = "Priya", Branch = "IT", Sem = 5, CPI = 9, Age = 21 },
             new Student { Rno = 3, Name = "Rahul", Branch = "CE", Sem = 1, CPI = 7, Age = 20},
             new Student { Rno = 4, Name = "Sneha", Branch = "ME", Sem = 7, CPI = 8, Age = 19 },
             new Student { Rno = 5, Name = "Karan", Branch = "IT", Sem = 3, CPI = 6, Age = 20 }
            };

            var courses = new List<Course>
            {
             new Course { Rno = 1, CourseName = "DBMS", Credits = 4 },
             new Course { Rno = 1, CourseName = "C#", Credits = 3 },
             new Course { Rno = 2, CourseName = "Java", Credits = 4 },
             new Course { Rno = 3, CourseName = "Python", Credits = 3 },
             new Course { Rno = 5, CourseName = "AI", Credits = 5 }
            };

            //1.Get all CE branch students.
            var ceStudents = students.
                Where(s => s.Branch == "CE").
                ToList();
            Console.WriteLine("CE Branch Students:");
            foreach (var student in ceStudents)
            {
                Console.WriteLine($"Rno: {student.Rno}, Name: {student.Name}, Branch: {student.Branch}, Sem: {student.Sem}, CPI: {student.CPI}, Age: {student.Age}");
            }
            Console.WriteLine();

            //2.Students having CPI > 8.
            var highCPIStudents = students.
                Where(s => s.CPI > 8).
                ToList();
            Console.WriteLine("Students with CPI > 8:");
            foreach (var student in highCPIStudents)
            {
                Console.WriteLine($"Rno: {student.Rno}, Name: {student.Name}, Branch: {student.Branch}, Sem: {student.Sem}, CPI: {student.CPI}, Age: {student.Age}");
            }
            Console.WriteLine();

            //3.Students older than 20.
            var olderStudents = students.
                Where(s => s.Age > 20).
                ToList();

            //4.Students in Semester 3.
            var sem3Students = students.
                Where(s => s.Sem == 3).
                ToList();

            //5.CPI between 7 and 9.
            var cpiBetweenStudents = students.
                Where(s => s.CPI >= 7 && s.CPI <= 9).
                ToList();

            //6.Name starting with 'A'.
            var nameAStudents = students.
                Where(s => s.Name.StartsWith("A")).
                ToList();

            //7.Branch = IT AND Sem = 3.
            var itSem3Students = students.
                Where(s => s.Branch == "IT" && s.Sem == 3).
                ToList();

            //8.Age < 20 OR CPI > 8.
            var ageCPIStudents = students.
                Where(s => s.Age < 20 || s.CPI > 8).
                ToList();

            //9.Names containing 'a'.
            var nameContainingAStudents = students.
                Where(s => s.Name.Contains("a")).
                ToList();

            //10.Students NOT in CE.
            var notCEStudents = students.
                Where(s => s.Branch != "CE").
                ToList();

            //11.Sem in { 1,3,5}.
            var oddSemStudents = students.
                Where(s => s.Sem == 1 || s.Sem == 3 || s.Sem == 5).
                ToList();

            //12.Students whose CPI is a whole number.
            var wholeCPIStudents = students.
                Where(s => s.CPI % 1 == 0).
                ToList();

            //13.Students with even Roll No.
            var evenRnoStudents = students.
                Where(s => s.Rno % 2 == 0).
                ToList();

            //14.Students whose age is between 18 and 21.
            var ageBetweenStudents = students.
                Where(s => s.Age >= 18 && s.Age <= 21).
                ToList();

            //15.Students having name length > 4.
            var longNameStudents = students.
                Where(s => s.Name.Length > 4).
                ToList();
            Console.WriteLine("Students with Name Length > 4:");
            foreach (var student in longNameStudents)
            {
                Console.WriteLine($"Rno: {student.Rno}, Name: {student.Name}, Branch: {student.Branch}, Sem: {student.Sem}, CPI: {student.CPI}, Age: {student.Age}");
            }
            Console.WriteLine();

            //SECTION 2 — SELECT(Projection) — 10
            //Questions

            //16.Select only names.
            var studentNames = students.
                Select(s => s.Name).
                ToList();

            //17.Select Name + CPI.
            var nameCPIStudents = students.
                Select(s => new { s.Name, s.CPI }).
                ToList();

            //18.Select Roll No +Branch.
            var rnoBranchStudents = students.
                Select(s => new { s.Rno, s.Branch }).
                ToList();

            //19.Select anonymous type: Name, Sem, Age.
            var nameSemAgeStudents = students.
                Select(s => new { s.Name, s.Sem, s.Age }).
                ToList();

            //20.Create 'FullInfo' string(e.g., "Name (Branch)").
            var fullInfoStudents = students.
                Select(s => $"{s.Name} ({s.Branch})").
                ToList();

            //21.Project all to CPI only.
            var cpiOnlyStudents = students.
                Select(s => s.CPI).
                ToList();

            //22.Select Name in lowercase.
            var lowerCaseNameStudents = students.
                Select(s => s.Name.ToLower()).
                ToList();

            //23.Select Name + Status based on CPI(Good / Average).
            var nameStatusStudents = students.
                Select(s => new
                {
                    s.Name,
                    Status = s.CPI >= 8 ? "Good" : "Average"
                }).
                ToList();

            //24.Extract only distinct branches.
            var distinctBranches = students.
                Select(s => s.Branch).
                Distinct().
                ToList();

            //25.Convert student to “DTO” format(Rno, Name).
            var studentDTOs = students.
                Select(s => new { s.Rno, s.Name }).
                ToList();
            Console.WriteLine("Student DTOs (Rno, Name):");
            foreach (var dto in studentDTOs)
            {
                Console.WriteLine($"Rno: {dto.Rno}, Name: {dto.Name}");
            }

            //SECTION 3 — SORTING(OrderBy) — 10
            //Questions
            //26.Sort names alphabetically.
            var sortedByName = students.
                OrderBy(s => s.Name).
                ToList();
            Console.WriteLine("Students Sorted by Name:");
            foreach (var student in sortedByName)
            {
                Console.WriteLine($"Rno: {student.Rno}, Name: {student.Name}, Branch: {student.Branch}, Sem: {student.Sem}, CPI: {student.CPI}, Age: {student.Age}");
            }
            Console.WriteLine();

            //27.Sort by CPI descending.
            var sortedByCPIDesc = students.
                OrderByDescending(s => s.CPI).
                ToList();

            //28.Sort by Sem, then Name.

            //29.Sort by Age, then CPI desc.
            //30.Sort by Branch.
            //31.Sort by Name length.
            //32.Sort by Sem DESC.
            //33.Sort by CPI then Age.
            //34.Sort by Rno descending.
            //35.Sort by Branch then Sem.

        }

    }
}
