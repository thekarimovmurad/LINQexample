using LINQdata;
using LINQextensions;

List<Employee> employeeList = new List<Employee>();
var filteredEmployees = employeeList.Filter(emp => emp.IsManager == true);
