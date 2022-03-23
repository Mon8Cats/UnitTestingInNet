using System;
using System.Collections.Generic;

namespace SkSampleLibrary.Moq
{
    public interface IPersonDatabase
    {
        event EventHandler PersonAdded;
        event EventHandler PersonDeleted;

        string ConnectionString { get; set; }

        void AddPerson(Person person);
        void DeletePerson(Person person);
        bool UpdatePerson(Person person);
        Person GetPerson(int id);
        IList<Person> GetAll();
    }
}
