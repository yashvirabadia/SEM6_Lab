namespace Lab5_Practice_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            var departments = new List<Department>
            {
                new Department { DeptId = 1, DeptName = "HR" },
                new Department { DeptId = 2, DeptName = "IT" },
                new Department { DeptId = 3, DeptName = "Finance" },
                new Department { DeptId = 4, DeptName = "Marketing" }
            };

            var employees = new List<Employee>
            {
                new Employee { Id = 101, Name = "Amit",   Age = 28, Salary = 75000, DeptId = 2, Skills = new List<string>{ "C#", "SQL", "Angular" } },
                new Employee { Id = 102, Name = "Neha",   Age = 34, Salary = 95000, DeptId = 2, Skills = new List<string>{ "Java", "C#", "React" } },
                new Employee { Id = 103, Name = "Raj",    Age = 45, Salary = 60000, DeptId = 1, Skills = new List<string>{ "Excel", "Communication" } },
                new Employee { Id = 104, Name = "Priya",  Age = 29, Salary = 82000, DeptId = 3, Skills = new List<string>{ "Accounting", "SQL" } },
                new Employee { Id = 105, Name = "Karan",  Age = 31, Salary = 88000, DeptId = 2, Skills = new List<string>{ "C#", "Azure", "Docker" } },
                new Employee { Id = 106, Name = "Simran", Age = 26, Salary = 72000, DeptId = 4, Skills = new List<string>{ "Design", "Photoshop" } }
            };

            //Get a list containing only the names of all employees.
            var employeeNames = employees.
                Select(e => e.Name).
                ToList();
            Console.WriteLine("Names of all employees:");
            foreach (var name in employeeNames)
                Console.WriteLine(name);
            Console.WriteLine("--------------------------------------------------");


            //Create a list of anonymous objects with each employee’s Name and Annual Salary (Salary × 12).
            var employeeAnnualSalaries = employees.
                Select(e => new { e.Name, AnnualSalary = e.Salary * 12 }).
                ToList();
            Console.WriteLine("Employee Names and their Annual Salaries:");
            foreach (var item in employeeAnnualSalaries)
                Console.WriteLine($"Name: {item.Name}, Annual Salary: {item.AnnualSalary}");
            Console.WriteLine("--------------------------------------------------");

            //Retrieve Name and Salary of all employees older than 30 years.
            var employeesOlderThan30 = employees.
                Where(e => e.Age > 30).
                Select(e => new { e.Name, e.Salary }).
                ToList();
            Console.WriteLine("Employees older than 30 years:");
            foreach (var item in employeesOlderThan30)
                Console.WriteLine($"Name: {item.Name}, Salary: {item.Salary}");
            Console.WriteLine("--------------------------------------------------");

            //Show complete details of all employees who belong to the IT department.
            var EmployeesInIT = from e in employees
                                        join d in departments on e.DeptId equals d.DeptId
                                        where d.DeptName == "IT"
                                        select e;
            Console.WriteLine("Employees in IT Department:");
            foreach (var emp in EmployeesInIT)
                Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}, DeptId: {emp.DeptId}, Skills: {string.Join(", ", emp.Skills)}");

            Console.WriteLine("--------------------------------------------------");

            //Produce a single flat list of every skill known by any employee.
            var allSkills = employees.
                SelectMany(e => e.Skills).
                ToList();
            Console.WriteLine("All skills known by employees:");
            foreach (var skill in allSkills)
                Console.Write(skill+" ");
            Console.WriteLine("--------------------------------------------------");

            //Get a list of all unique skills present in the company (no duplicates).
            var uniqueSkills = employees.
                SelectMany(e => e.Skills).
                Distinct().
                ToList();
            Console.WriteLine("Unique skills in the company:");
            foreach (var skill in uniqueSkills)
                Console.Write(skill+" ");
            Console.WriteLine("--------------------------------------------------");

            //List all skills known by employees earning more than 80,000.
            var skillsOfHighEarners = employees.
                Where(e => e.Salary > 80000).
                SelectMany(e => e.Skills).
                Distinct().
                ToList();
            Console.WriteLine("Skills known by employees earning more than 80,000:");
            foreach (var skill in skillsOfHighEarners)
                Console.Write(skill+" ");
            Console.WriteLine("--------------------------------------------------");

            //Given this mixed list:
            //List<object> mixed = new List<object> { employees[0], "hello", employees[1], 999, employees[2] };
            //Extract only the actual Employee objects.

            List<object> mixed = new List<object> { employees[0], "hello", employees[1], 999, employees[2] };
            var extractedEmployees = mixed.
                OfType<Employee>().
                ToList();
            Console.WriteLine("Extracted Employee objects from mixed list:");
            foreach (var emp in extractedEmployees)
                Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Age: {emp.Age}, Salary: {emp.Salary}, DeptId: {emp.DeptId}, Skills: {string.Join(", ", emp.Skills)}");
            Console.WriteLine("--------------------------------------------------");

            //From the mixed list above, extract only the names of the Employee objects.
            var extractedEmployeeNames = mixed.
                OfType<Employee>().
                Select(e => e.Name).
                ToList();
            Console.WriteLine("Names of extracted Employee objects from mixed list:");
            foreach (var name in extractedEmployeeNames)
                Console.WriteLine(name);
            Console.WriteLine("--------------------------------------------------");

        }
    }
}
