using HW_14__05_20.Interfaces;
using HW_14__05_20.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_14__05_20.Printer
{
     class ConsolePrinter : IPrinterText, IPrinterPerson,IPrinterStudent
    {
        public void PrintPerson(Person person)
        {
          Console.WriteLine($"Id: {person.Id} |  LastName: {person.LastName} |  FirstName: {person.FirstName} |  BirthYear: {person.BirthYear}");
        }

        public void PrintStudent(Student student)
        {
            Console.WriteLine($"Id: {student.Id} |  LastName: {student.LastName} |  FirstName: {student.FirstName} |  BirthYear: {student.BirthYear} |  Nation: {student.Nation} |  Gender: {student.Gender} |  Age: {DateTime.Now.Year - student.BirthYear} |  University: {student.University} |  Faculty: {student.Faculty} |  Specialty: {student.Specialty} |  Login:  {student.Login} |  Password: {student.Password}");
        }

        public void PrintText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
