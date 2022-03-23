using System;

namespace SkSampleLibrary.Moq
{
    public class PersonService
    {
        IPersonDatabase _personDb;
        public PersonService(IPersonDatabase personDb)
        {
            _personDb = personDb;
        }

        public void AddPerson(Person person)
        {
            //Check business rules here…
            _personDb.AddPerson(person);
        }

        public void DeletePerson(Person person)
        {
            //Check business rules here…
            _personDb.DeletePerson(person);
        }

        public Person GetPerson(int id)
        {
            //Check security etc…  
            return _personDb.GetPerson(id);
        }
    }
}
