using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
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
            var sortedBySemThenName = students.
                OrderBy(s => s.Sem).
                ThenBy(s => s.Name).
                ToList();

            //29.Sort by Age, then CPI desc.
            var sortedByAgeThenCPIDesc = students.
                OrderBy(s => s.Age).
                ThenByDescending(s => s.CPI).
                ToList();

            //30.Sort by Branch.
            var sortedByBranch = students.
                OrderBy(s => s.Branch).
                ToList();

            //31.Sort by Name length.
            var sortedByNameLength = students.
                OrderBy(s => s.Name.Length).
                ToList();
            Console.WriteLine("Students Sorted by Name Length:");
            foreach (var student in sortedByNameLength)
            {
                Console.WriteLine($"Rno: {student.Rno}, Name: {student.Name}, Branch: {student.Branch}, Sem: {student.Sem}, CPI: {student.CPI}, Age: {student.Age}");
            }
            Console.WriteLine();

            //32.Sort by Sem DESC.
            var sortedBySemDesc = students.
                OrderByDescending(s => s.Sem).
                ToList();

            //33.Sort by CPI then Age.
            var sortedByCPIThenAge = students.
                OrderBy(s => s.CPI).
                ThenBy(s => s.Age).
                ToList();

            //34.Sort by Rno descending.
            var sortedByRnoDesc = students.
                OrderByDescending(s => s.Rno).
                ToList();

            //35.Sort by Branch then Sem.
            var sortedByBranchThenSem = students.
                OrderBy(s => s.Branch).
                ThenBy(s => s.Sem).
                ToList();

            //SECTION 4 — AGGREGATION — 10Questions
            //36.
            //Count total students.
            var totalStudents = students.Count();

            //37.
            //Count CE students.
            var ceStudent = students.
                Count(s => s.Branch == "CE");

            //38.
            //Max CPI.
            var maxCPI = students.
                Max(s => s.CPI);

            //39.
            //Min CPI.
            var minCPI = students.
                Min(s => s.CPI);

            //40.
            //Average CPI.
            var averageCPI = students.
                Average(s => s.CPI);

            //41.
            //Total credits for Rno = 1.
            var totalCredits = courses.
                Where(c => c.Rno == 1).
                Sum(c => c.Credits);

            //42.
            //Oldest student's age.
            var oldestAge = students.
                Max(s => s.Age);

            //43.
            //Youngest student's age.
            var youngestAge = students.
                Min(s => s.Age);

            //44.
            //Highest Sem.
            var highestSem = students.
                Max(s => s.Sem);

            //45.
            //Sum of all credits.
            var sumOfAllCredits = courses.
                Sum(c => c.Credits);

            //SECTION 5 — ELEMENT OPERATIONS — 10Questions
            //46.
            //Get first student.
            var firstStudent = students.FirstOrDefault();

            //47.
            //First student with CPI > 9.
            var highCPIStudent = students.
                FirstOrDefault(s => s.CPI > 9);

            //48.
            //Last student.
            var lastStudent = students.
                LastOrDefault();

            //49.
            //Get student at index 2.
            var studentAtIndex2 = students.
                ElementAtOrDefault(2);

            //50.
            //Single student with Rno = 3.
            var singleStudentRno3 = students.
                Single(s => s.Rno == 3);

            //51.
            //Safe single(e.g., Rno = 10).
            var safeSingleStudent = students.
                SingleOrDefault(s => s.Rno == 10);

            //52. First IT student.
            var firstITStudent = students
                .FirstOrDefault(s => s.Branch == "IT");

            //53. Last CE student.
            var lastCEStudent = students
                .LastOrDefault(s => s.Branch == "CE");

            //54. First student older than 18.
            var firstOlderThan18 = students
                .FirstOrDefault(s => s.Age > 18);

            //55. Element at index 0.
            var studentAtIndex0 = students
                .ElementAtOrDefault(0);

            //SECTION 6 — ANY / ALL — 10 Questions
            //56. Any CE students ?
            var anyCE = students
                .Any(s => s.Branch == "CE");

            //57. All students older than 17 ?
            var allOlderThan17 = students
                .All(s => s.Age > 17);

            //58. Any CPI > 9 ?
            var anyCPIGreaterThan9 = students
                .Any(s => s.CPI > 9);

            //59. All semesters are > 0 ?
            var allSemGreaterThan0 = students
                .All(s => s.Sem > 0);

            //60. Any student with name length > 6 ?
            var anyLongName = students
                .Any(s => s.Name.Length > 6);

            //61. All belong to CE ?
            var allCE = students
                .All(s => s.Branch == "CE");

            //62. Any course with credits > 4 ?
            var anyCourseCreditsGT4 = courses
                .Any(c => c.Credits > 4);

            //63. All credits > 2 ?
            var allCreditsGT2 = courses
                .All(c => c.Credits > 2);

            //64. Any course named "Java" ?
            var anyJavaCourse = courses
                .Any(c => c.CourseName == "Java");

            //65. Any student younger than 18 ?
            var anyYoungerThan18 = students
                .Any(s => s.Age < 18);

            //SECTION 7 — GROUPING — 10 Questions
            //66. Group students by branch.
            var studentsByBranch = students
                .GroupBy(s => s.Branch);

            //67. Group by Semester.
            var studentsBySemester = students
                .GroupBy(s => s.Sem);

            //68. Group by Age.
            var studentsByAge = students
                .GroupBy(s => s.Age);

            //69. Group by CPI category (High / Low).
            var studentsByCPICategory = students
                .GroupBy(s => s.CPI >= 8 ? "High" : "Low");

            //70. Group courses by Rno.
            var coursesByRno = courses
                .GroupBy(c => c.Rno);

            //71. Group students by first letter of name.
            var studentsByFirstLetter = students
                .GroupBy(s => s.Name[0]);

            //72. Group by Branch then Sem.
            var studentsByBranchThenSem = students
                .GroupBy(s => new { s.Branch, s.Sem });

            //73. Group by age range (Teen / Adult).
            var studentsByAgeRange = students
                .GroupBy(s => s.Age < 20 ? "Teen" : "Adult");

            //74. Group courses by Credits.
            var coursesByCredits = courses
                .GroupBy(c => c.Credits);

            //75. Group students by CPI rounded.
            var studentsByRoundedCPI = students
                .GroupBy(s => Math.Round(s.CPI));

            //SECTION 8 — JOIN — 10 Questions
            //76. Inner Join students + courses.
            var studentCourseJoin = students
                .Join(courses,
                      s => s.Rno,
                      c => c.Rno,
                      (s, c) => new { s.Name, c.CourseName });

            //77. Total credits per student.
            var totalCreditsPerStudent = students
                .Join(courses,
                      s => s.Rno,
                      c => c.Rno,
                      (s, c) => new { s.Name, c.Credits })
                .GroupBy(x => x.Name)
                .Select(g => new { Name = g.Key, TotalCredits = g.Sum(x => x.Credits) });

            //78. Students with courses.
            var studentsWithCourses = students
                .Join(courses,
                      s => s.Rno,
                      c => c.Rno,
                      (s, c) => new { s.Name, c.CourseName, c.Credits });

            //79. Left join.
            var leftJoin = students
                .GroupJoin(courses,
                           s => s.Rno,
                           c => c.Rno,
                           (s, c) => new { s.Name, Courses = c });

            //80. Distinct courses.
            var distinctCourses = courses
                .Select(c => c.CourseName)
                .Distinct();

            //81. Students having more than 1 course.
            var studentsWithMultipleCourses = courses
                .GroupBy(c => c.Rno)
                .Where(g => g.Count() > 1);

            //82. Join and order by credits.
            var joinOrderedByCredits = students
                .Join(courses,
                      s => s.Rno,
                      c => c.Rno,
                      (s, c) => new { s.Name, c.CourseName, c.Credits })
                .OrderByDescending(x => x.Credits);

            //83. IT students with courses.
            var itStudentsWithCourses = students
                .Where(s => s.Branch == "IT")
                .Join(courses,
                      s => s.Rno,
                      c => c.Rno,
                      (s, c) => new { s.Name, c.CourseName });

            //84. Students who have no course.
            var studentsWithNoCourse = students
                .Where(s => !courses.Any(c => c.Rno == s.Rno));

            //85. Students + number of courses.
            var studentCourseCount = students
                .Select(s => new
                {
                    s.Name,
                    CourseCount = courses.Count(c => c.Rno == s.Rno)
                });

            //SECTION 9 — SET OPERATIONS — 5Questions
            //86. Distinct branches.
            var distinctBranchList = students
                .Select(s => s.Branch)
                .Distinct();

            //87. CE or IT students (Union).
            var ceOrItStudents = students
                .Where(s => s.Branch == "CE")
                .Union(students.Where(s => s.Branch == "IT"));

            //88. CE but not IT.
            var ceNotItStudents = students
                .Where(s => s.Branch == "CE")
                .Except(students.Where(s => s.Branch == "IT"));

            //89. Common semesters between CE and IT.
            var commonSemesters = students
                .Where(s => s.Branch == "CE")
                .Select(s => s.Sem)
                .Intersect(students.Where(s => s.Branch == "IT")
                                   .Select(s => s.Sem));

            //90. Courses with credits other than 3.
            var nonThreeCreditCourses = courses
                .Where(c => c.Credits != 3);

            //SECTION 10 — CONVERSION(ToList, Dictionary) — 5 Questions
            //91. Convert to list.
            var studentList = students.ToList();

            //92. Dictionary (Rno → Name).
            var studentDictionary = students
                .ToDictionary(s => s.Rno, s => s.Name);

            //93. Names to array.
            var nameArray = students
                .Select(s => s.Name)
                .ToArray();

            //94. Lookup (Rno → Courses).
            var courseLookup = courses
                .ToLookup(c => c.Rno);

            //95. Branch HashSet.
            var branchHashSet = students
                .Select(s => s.Branch)
                .ToHashSet();

            //SECTION 11 — BASIC / MIXED — 5Questions
            //96. Top 2 highest CPI students.
            var top2CPIStudents = students
                .OrderByDescending(s => s.CPI)
                .Take(2);

            //97. Skip first 2, take next 2.
            var skipTakeStudents = students
                .Skip(2)
                .Take(2);

            //98. Student with max CPI (full object).
            var studentWithMaxCPI = students
                .OrderByDescending(s => s.CPI)
                .FirstOrDefault();

            //99. Students with course count + sort.
            var studentsWithCourseCountSorted = students
                .Select(s => new
                {
                    s.Name,
                    CourseCount = courses.Count(c => c.Rno == s.Rno)
                })
                .OrderByDescending(x => x.CourseCount);

            //100. Grouped by Branch + sorted by CPI.
            var groupedByBranchSortedByCPI = students
                .GroupBy(s => s.Branch)
                .Select(g => new
                {
                    Branch = g.Key,
                    Students = g.OrderByDescending(s => s.CPI)
                });



        }

    }
}
