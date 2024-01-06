using LINQdata;
using LINQextensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

//List<Employee> employeeList = Data.GetEmployees();
//var filteredEmployees = employeeList.Filter(emp => emp.IsManager == true);

//foreach (var employee in filteredEmployees)
//{
//    Console.WriteLine($"First Name: {employee.FirstName}");
//    Console.WriteLine($"Last Name: {employee.LastName}");
//    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
//    Console.WriteLine($"Manager: {employee.IsManager}");
//}

//List<Department> departmentList = Data.GetDepartments();
//var filteredDepartments = departmentList.Where(dep => dep.Id>=2);

//foreach (var department in filteredDepartments)
//{
//    Console.WriteLine($"ID: {department.Id}");
//    Console.WriteLine($"Short Name: {department.ShortName}");
//    Console.WriteLine($"Long Name: {department.LongName}");
//}

List<Department> departmentList = Data.GetDepartments();
List<Employee> employeeList = Data.GetEmployees();

var resultList = from emp in employeeList
                 join dep in departmentList
                 on emp.DepartmentId equals dep.Id
                 select new
                 {
                     FirstName = emp.FirstName,
                     LastName = emp.LastName,
                     AnnualSalary = emp.AnnualSalary,
                     Manager = emp.IsManager,
                     Department = dep.LongName
                 };
//foreach (var employee in resultList)
//{
//    Console.WriteLine($"First Name: {employee.FirstName}");
//    Console.WriteLine($"Last Name: {employee.LastName}");
//    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
//    Console.WriteLine($"Manager: {employee.Manager}");
//    Console.WriteLine($"Manager: {employee.Department}");
//    Console.WriteLine("********");
//}

var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
var maxAnnualSalary = resultList.Max(a => a.AnnualSalary);
var minAnnualSalary = resultList.Min(a => a.AnnualSalary);

Console.WriteLine($"average annual salary: {averageAnnualSalary}");
Console.WriteLine($"max annual salary: {maxAnnualSalary}");
Console.WriteLine($"min annual salary: {minAnnualSalary}");

//Console.ReadKey(); 