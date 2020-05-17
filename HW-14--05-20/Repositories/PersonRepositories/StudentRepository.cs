using Dapper;
using HW_14__05_20.Interfaces;
using HW_14__05_20.Persons;
using HW_14__05_20.Printer;
using System;
using System.Data;
using System.Data.SqlClient;
namespace HW_14__05_20.Repositories.PersonRepositories
{
    class StudentRepository : RepositoryBase<Student>, ICRUD
    {
        public StudentRepository() : base()
        {
        }
        ConsolePrinter ConsolePrint = new ConsolePrinter();
        public void Create()
        {
            Student student = new Student();
            Console.Write("LastName: "); student.LastName = Console.ReadLine();
            Console.Write("FirstName: "); student.FirstName = Console.ReadLine();
            Console.Write("BirthYear: "); student.BirthYear = int.Parse(Console.ReadLine());
            Console.Write("Nation: "); student.Nation = Console.ReadLine();
            Console.Write("Gender: "); student.Gender = Console.ReadLine();
            Console.Write("University: "); student.University = Console.ReadLine();
            Console.Write("Faculty: "); student.Faculty = Console.ReadLine();
            Console.Write("Specialty: "); student.Specialty = Console.ReadLine();
            Console.Write("Login: "); student.Login = int.Parse(Console.ReadLine());
            Console.Write("Password: "); student.Password = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(ConnString))
                {
                    var command = $"INSERT INTO Student([LastName],[FirstName],[BirthYear],[Nation],[Gender],[Age],[University],[Faculty],[Specialty],[Login],[Password]) VALUES('{student.LastName}','{student.FirstName}',{student.BirthYear},'{student.Nation}','{student.Gender}',{DateTime.Now.Year - student.BirthYear},'{student.University}','{student.Faculty}','{student.Specialty}',{student.Login},{student.Password}); SELECT CAST(SCOPE_IDENTITY() AS INT)";
                    db.Query<int>(command, student);
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
            foreach (var item in SelectAll())
            {
                ConsolePrint.PrintStudent(item);
            }
        }
        public void Update()
        {
            Read();
            ConsolePrint.PrintText("Введите ID человека каторый вы хотели изменит его данны!!!");
            Console.Write("ID: ");
            int ID = int.Parse(Console.ReadLine()); Console.Clear();
            Student student = new Student();
            Console.Write("LastName: "); student.LastName = Console.ReadLine();
            Console.Write("FirstName: "); student.FirstName = Console.ReadLine();
            Console.Write("BirthYear: "); student.BirthYear = int.Parse(Console.ReadLine());
            Console.Write("University: "); student.University = Console.ReadLine();
            Console.Write("Faculty: "); student.Faculty = Console.ReadLine();
            Console.Write("Specialty: "); student.Specialty = Console.ReadLine();
            Console.Write("Login: "); student.Login = int.Parse(Console.ReadLine());
            Console.Write("Password: "); student.Password = int.Parse(Console.ReadLine());
            try
            {
                using (IDbConnection db = new SqlConnection(ConnString))
                {
                    var command = $"UPDATE Student SET LastName = '{student.LastName}', FirstName = '{student.FirstName}',BirthYear ={student.BirthYear},Nation='{student.Nation}',Gender='{student.Gender}',Age={DateTime.Now.Year - student.BirthYear},University='{student.University}',Faculty='{student.Faculty}',Specialty='{student.Specialty}',Login={student.Login},Password={student.Password} WHERE Id = {ID}";
                    db.Execute(command, student);
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
