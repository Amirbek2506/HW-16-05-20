using Dapper;
using HW_14__05_20.Interfaces;
using HW_14__05_20.Persons;
using HW_14__05_20.Printer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HW_14__05_20.Repositories.PersonRepositories
{
    class PersonRepository : RepositoryBase<Person>,ICRUD
    {
        public PersonRepository():base()
        {
        }
        ConsolePrinter ConsolePrint = new ConsolePrinter();
        public void Create()
        {
            Person person = new Person();
            Console.Write("LastName: ");person.LastName= Console.ReadLine();
            Console.Write("FirstName: ");person.FirstName= Console.ReadLine();
            Console.Write("BirthYear: ");person.BirthYear = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(ConnString))
                {
                    var command = $"INSERT INTO Person([LastName],[FirstName],[BirthYear]) VALUES('{person.LastName}','{person.FirstName}',{person.BirthYear}); SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    db.Query<int>(command, person);
                    ConsolePrint.PrintText("Успешно добавлен!");
                }
            }
            catch (SqlException ex)
            {
                ConsolePrint.PrintText($"Error: {ex.Message}");
            }
        }
        public void Read()
        {
           foreach(var item in SelectAll())
            {
              ConsolePrint.PrintPerson(item);
            }
        }
        public void Update()
        {
            Read();
            ConsolePrint.PrintText("Введите ID человека каторый вы хотели изменит его данны!!!");
            Console.Write("ID: ");
            int ID = int.Parse(Console.ReadLine());Console.Clear();
            Person person = new Person();
            Console.Write("LastName: ");person.LastName= Console.ReadLine();
            Console.Write("FirstName: ");person.FirstName= Console.ReadLine();
            Console.Write("BirthYear: ");person.BirthYear =int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(ConnString))
                {
                    var command = $"UPDATE Person SET LastName = '{person.LastName}', FirstName = '{person.FirstName}',BirthYear ={person.BirthYear} WHERE Id = {ID}";
                    db.Execute(command, person);
                    ConsolePrint.PrintText("Успешно изменено!");
                }
            }
            catch (SqlException ex)
            {
                ConsolePrint.PrintText($"Error: {ex.Message}");
            }
        }
        public void Delete()
        {
            Read();
            DeleteById();
        }
    }
}
