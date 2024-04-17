using System;
using System.Collections;
using System.Collections.Generic;

class Employee
{
    public int empID;
    public string empName;
    public int empAge;
    public int empContactNo;
}

class visitingEmployee : Employee
{
    public int visitingSalary;
    public int visitingHours;

}

class permanetEmployee : Employee
{
    public int permanetSalary;
    public int permanetHours;

}

class display
{
    public static void main(string[] args)
    {
        permanetEmployee pe = new permanetEmployee();
        pe.permanetSalary = 40000;
        pe.permanetHours = 5;
        pe.empName = "PE";
        pe.empAge = 27;
        pe.empContactNo= 12345;
        pe.empID = 122;
    }
}