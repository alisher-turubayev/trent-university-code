using System;
public static class EmployeeDemo
{
    public static void Main()
    {
        // Create Employee objects utilizing different constructors
        Employee emp1 = new Employee();
        Employee emp2 = new Employee("Joy Rogers", 10127, "HR", "Manager");
        Employee emp3 = new Employee("Mark Jones", 10065);

        // Use Properties to assign values to data fields
        emp1.Name = "Susan Meyers";
        emp1.idNumber = 10012;
        emp1.Department = "Accounting";
        emp1.Position = "Vice President";

        emp3.Department = "IT";
        emp3.Position = "Support";

        // Use Properties to output data from Employee objects
        Console.WriteLine("Employee 1: {0}, {1}, {2}, {3}",
           emp1.Name, emp1.IdNumber, emp1.Department, emp1.Position);
        Console.WriteLine("Employee 2: {0}, {1}, {2}, {3}", 
           emp2.Name, emp2.IdNumber, emp2.Department, emp2.Position);
        Console.WriteLine("Employee 3: {0}, {1}, {2}, {3}", 
           emp3.Name, emp3.IdNumber, emp3.Department, emp3.Position);
        Console.ReadLine();
    }
}