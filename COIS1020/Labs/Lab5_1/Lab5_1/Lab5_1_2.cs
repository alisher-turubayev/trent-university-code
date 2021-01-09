using System;	// Code File Lab5_1_2.cs
public class Employee	// this is a dynamic class (no �static�)
{
    public int idNumber;
    private string name, department, position;

    public Employee() // Constructor 1: No Arg
    {
        Name = "";
        IdNumber = 0;
        Department = "";
        Position = "";
    }

    public Employee(string eName, int eIdNum) // Constructor 2: Two Arg
    {
        Name = eName;
        IdNumber = eIdNum;
        Department = "";
        Position = "";
    }

    // Constructor 3: Four Arg
    public Employee(string eName, int eIdNum, string eDept, string ePos)
    {
        Name = eName;
        IdNumber = eIdNum;
        Department = eDept;
        Position = ePos;
    }

    public string Name  // Property for priviate data - name
    {
        get { return name; }
        set { name = value; }
    }

    public int IdNumber     // Property for priviate data - idNumber
    {
        get { return idNumber; }
        set { idNumber = value; }
    }

    public string Department    // Property for priviate data � department
    {
        get { return department; }
        set { department = value; }
    }

    public string Position  // Property for priviate data - position

    {
        get { return position; }
        set { position = value; }
    }
}
