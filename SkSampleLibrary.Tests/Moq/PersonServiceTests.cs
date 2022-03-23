using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using SkSampleLibrary.Moq;

namespace SkSampleLibrary.Tests.Moq
{
    public class PersonServiceTests
    {
        [Fact]
        public void moq_tests()
        {
            //Arrange
            var mock = new Mock<IPersonDatabase>();
            mock.Setup(db => db.AddPerson(It.IsAny<Person>()));//.Verifiable();
            mock.Setup(db => db.GetPerson(It.IsAny<int>())).Returns(new Person()).Verifiable();
            mock.Setup(db => db.GetPerson(It.IsAny<int>())).Returns(()=>
            {
                var person = new Person();
                person.Id = 2;
                return person;
            });

            mock.Setup(db => db.UpdatePerson(It.IsAny<Person>())).Throws<ArgumentException>();
            mock.Setup(db => db.UpdatePerson(It.IsAny<Person>())).Throws(new ArgumentNullException());

            List<Person> personList = new List<Person>();
            mock.Setup(db => db.AddPerson(It.IsAny<Person>())).Callback<Person>(p =>
             {
                 personList.Add(p);
             });

            mock.Setup(db => db.GetPerson(It.IsAny<int>())).Returns<int>(id =>
              {
                  return personList.FirstOrDefault(x => x.Id == id);
              });

            mock.Setup(m => m.GetAll()).Returns(() => new List<Person>());

            var sut = new PersonService(mock.Object);

            /*
            // Setup a method to provide a facke impementation for a method takse a parameter
            mock.Setup(m => m.UpdatePerson(It.IsAny<Person>()))
                .Returns(true)
                .Callback<Person>( p => { p.Name = "my name"}); // I can us this passed Person parameter here
            */


            //Act
            //sut.AddPerson(new Person(1, "Name", "Surname"));

            mock.Object.AddPerson(new Person());
            mock.Object.ConnectionString = "sdfsdfsd";
            mock.Object.PersonAdded += (sender, args) =>
              {
                  //dsfsdfsd
              };
            mock.Object.GetAll();

            //Assert
            //mock.VerifyAll();// (db => db.AddPerson(It.IsAny<Person>()), Times.Once);   
            mock.Verify(db => db.AddPerson(It.IsAny<Person>()), Times.Once);
            mock.Verify(db => db.GetAll(), Times.Once);
        }
    }
}
