using System.Linq;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;
using Xunit;

namespace PhoneBookInterviewTests.PhoneBookTests
{
    public class UpdateTests
    {
        [Fact]
        public void Update_NewContact_AllContactsUpdated()
        {
            var updateName = "1234";
            var notUpdateName = "13";

            var book = new PhoneBook
            {
                new Contact
                {
                    FirstName = updateName
                },
                new Contact
                {
                    FirstName = updateName
                },
                new Contact
                {
                    FirstName = notUpdateName
                }
            };

            var newContact = new Contact();
            
            book.Update(x => x.FirstName == updateName, newContact);

            var newContactsCount = book.Count(x => x == newContact);
            Assert.Equal(newContactsCount, 2);
            Assert.NotEqual(book.Single(x => x.FirstName == notUpdateName ), newContact);
        }

        [Fact]
        public void Update_LambdaModifier_AllContactsUpdated()
        {
            var updateName = "1234";
            var notUpdateName = "13";
            var updatedLastName = "bbbb";

            var book = new PhoneBook
            {
                new Contact
                {
                    FirstName = updateName
                },
                new Contact
                {
                    FirstName = updateName
                },
                new Contact
                {
                    FirstName = notUpdateName
                }
            };
            

            book.Update(x => x.FirstName == updateName, x =>
            {
                x.LastName = updatedLastName;
                return x;
            });

            var updatedContactsCount = book.Count(x => x.FirstName == updateName && x.LastName == updatedLastName);
            var notUpdatedContactsCount = book.Count(x => x.LastName == null);

            Assert.Equal(updatedContactsCount, 2);
            Assert.Equal(notUpdatedContactsCount, 1);
        }
    }
}
