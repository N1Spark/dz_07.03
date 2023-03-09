using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_07._03
{
    class Program
    {
        enum Type { Marketing, IT, Restaurant, Construction }
        class Employee
        {
            public string Name { get; set; }
            public string Job { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public double Payment { get; set; }
            public Employee(string name, string job, string phone, string email, double pay)
            {
                Name = name;
                Job = job;
                Phone = phone;
                Email = email;
                Payment = pay;
            }
            public Employee() { }
            public override string ToString() { return $"Name: {Name}, Job: {Job}, Phone: {Phone}, Email: {Email}, Payment: {Payment}"; }
        }
        class Firm
        {
            public string Name { get; set; }
            public int FoundingDate { get; set; }
            public Type Profile { get; set; }
            public string DirectorName { get; set; }
            public int EmployeesCount { get; set; }
            public string Address { get; set; }
            public List<Employee> Employees { get; set; }
            public Firm()
            {
                Name = null;
                FoundingDate = 0;
                Profile = Type.IT;
                DirectorName = null;
                EmployeesCount = 0;
                Address = null;
                Employees = new List<Employee>();
            }
            public Firm(string name, int foundingDate, string Director, Type profile, int employeesCount, string address)
            {
                Name = name;
                FoundingDate = foundingDate;
                Profile = profile;
                DirectorName = Director;
                EmployeesCount = employeesCount;
                Address = address;
            }
            public Firm(string name, int foundingDate, string Director, Type profile, int employeesCount,
                string address, List<Employee> employees) : this(name, foundingDate, Director, profile, employeesCount, address)
            => employees = new List<Employee>();

            public override string ToString()
            {
                return $"Name: {Name}\nType: {Profile}\nFounded: {FoundingDate}\nDirector Name: {DirectorName}\nEmployees count: {EmployeesCount}\nAddress: {Address}\n";
            }
        }
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Nikita", "Manager", "543-987-3214", "nikita@email.com", 20000);
            Employee employee2 = new Employee("Dima", "Manager Assistant", "346-765-3725", "dima@email.com", 15000);
            Employee employee3 = new Employee("Petya", "Accountant", "763-125-2475", "petya@email.com", 30000);
            List<Employee> employees = new List<Employee> { employee1, employee2, employee3 };
            Firm firm1 = new Firm("Apple", 1976, "Tim Cook", Type.IT, 100, "One Apple Park Way, Cupertino, CA 95014", employees);
            Firm firm2 = new Firm("JYSK", 1979, "Lars Larsen", Type.Marketing, 100, "Brabrand", employees);
            List<Firm> firms = new List<Firm> { firm1, firm2 };

            #region Зад 1
            var firmInfo = from i in firms
                           select i.ToString();
            var FirmFood = firms.Where(i => i.Name.Contains("JYSK"));

            var firmsMarketing = firms.Where(i => i.Profile == Type.IT);

            var firmsMarketingOrIT = firms.Where(i => i.Profile == Type.IT || i.Profile == Type.IT);

            var NumberEmployeesMore100 = firms.Where(i => i.EmployeesCount > 100);

            var NumberEmployees100_300 = firms.Where(i => i.EmployeesCount > 100 && i.EmployeesCount < 300);

            var DirectorWhite = firms.Where(i => i.DirectorName.Contains("White"));

            var TowYear = firms.Where(i => i.FoundingDate < DateTime.Now.Year - 2);

            var BlackAndWhite = firms.Where(i => i.DirectorName.Contains("Black") && i.Name.Contains("White"));
            #endregion

            #region Зад 2
            var employeesInFirm = from e in employees
                                  from f in firms
                                  where f.Name == "Apple"
                                  select e;

            var employeesWage = from e in employees
                                from f in firms
                                where f.Name == "Apple"
                                where e.Payment > 30000
                                select e;

            var employeesManager = from e in employees
                                   from f in firms
                                   where e.Job == "Apple"
                                   select e;

            var employeesPhone = from e in employees
                                 from f in firms
                                 where f.Name == "Apple"
                                 where e.Phone.StartsWith("23")
                                 select e;

            var employeesEmail = from e in employees
                                 from f in firms
                                 where f.Name == "Apple"
                                 where e.Email.StartsWith("di")
                                 select e;

            var employeesName = from e in employees
                                from f in firms
                                where f.Name == "Apple"
                                where e.Name.Contains("Lionel")
                                select e;

            foreach (Employee temp in employeesName)
                Console.WriteLine(temp);
            #endregion
        }
    }
}
