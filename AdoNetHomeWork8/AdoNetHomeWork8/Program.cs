using System;
using System.Collections.Generic;
using static System.Console;

namespace AdoNetHomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            var search = new Search(new LBContext());
            bool start = true;

            void Writer(List<Person> persons)
            {
                foreach(var person in persons)
                {
                    WriteLine($"Имя: {person.LastName}");
                    WriteLine($"Фамилия: {person.FirstName}");
                    WriteLine($"Дата рождения: {person.DateOfBirth}");
                    WriteLine();
                }
                ReadLine();
            }

            int Reader()
            {
                bool isParsed = false;
                int result = 0;
                while (!isParsed)
                {
                    isParsed = int.TryParse(ReadLine(), out result);
                }
                return result;
            }

            string CreatHelper(string lastName)
            {
                WriteLine($"Введите {lastName}");
                return ReadLine();
            }

            DateTime ReaderDate()
            {
                WriteLine("Введите дата рождения:");
                string line = Console.ReadLine();
                DateTime dt;
                while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    Console.WriteLine("Дата рождения не правильно,введите повторно:");
                    line = Console.ReadLine();
                }

                return dt;
            }

            Person CreatePerson()
            {
                var book = new Person
                {
                    LastName = CreatHelper("Имя"),
                    FirstName = CreatHelper("Фамилия"),
                    DateOfBirth = ReaderDate()
                };               

                return book;
            }

            while (start)
            {
                Console.Clear();
                WriteLine("Введите 1,если хотите добавит человека\n" +
                    "Введите 2,если хотите делать поиск по ID \n" +
                    "Введите 3,если хотите делать поиск по Имю \n" +
                    "Введите 4,если хотите делать поиск по Фамилию \n" +
                    "Введите 5,если хотите делать поиск по Дата рождений \n" +
                    "Введите 6,если хотите выйти");

                int answer = Reader();

                switch (answer)
                {
                    case 1:
                        search.AddPersons(CreatePerson());                        
                        break;
                    case 2:
                        WriteLine("Введите ID:");
                        int id = Reader();
                        var resultById = search.GetById(id);
                        Writer(resultById);
                        break;
                    case 3:
                        WriteLine("Введите Имя:");
                        string lastName = ReadLine();
                        var resultByName = search.GetByLastName(lastName);
                        Writer(resultByName);
                        break;
                    case 4:
                        WriteLine("Введите Фамилия:");
                        string firstName = ReadLine();
                        var resultByAuthor = search.GetByFirstName(firstName);
                        Writer(resultByAuthor);
                        break;
                    case 5:
                        WriteLine("Введите Дату рождения:");
                        var dateOfBirth = Reader();
                        var resultByYear = search.GetByDate(dateOfBirth);
                        Writer(resultByYear);
                        break;
                    case 6:
                        start = false;
                        break;
                }
            }

        }
    }
}
