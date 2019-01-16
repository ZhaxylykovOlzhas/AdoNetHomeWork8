using System.Collections.Generic;
using System.Linq;
namespace AdoNetHomeWork8
{
    public class Search
    {
        LBContext _db;     
        public Search(LBContext db)
        {
            _db = db;
        }
        public void AddPersons(Person person)
        {            
            _db.Persons.Add(person);
            _db.SaveChanges();       
        }
        public List<Person> GetById(int id)
        {
            return _db.Persons.Where(b => b.Id == id).ToList();
        }
        public List<Person> GetByLastName(string lastName)
        {
            return _db.Persons.Where(b => b.LastName== lastName).ToList();
        }
        public List<Person> GetByFirstName(string firstName)
        {
            return _db.Persons.Where(b => b.FirstName == firstName).ToList();
        }
        public List<Person> GetByDate(int date)
        {
            return _db.Persons.Where(b => b.DateOfBirth.Year == date).ToList();
        }     
    }
}
