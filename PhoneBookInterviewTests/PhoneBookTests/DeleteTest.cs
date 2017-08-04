using System.Linq;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;
using Xunit;

namespace PhoneBookInterviewTests.PhoneBookTests
{
    public class DeleteTest
    {
        [Fact]
        public void Delete_Contact_ContactDeleted()
        {
            var deleteContact = new Contact();

            var book = new PhoneBook
            {
                new Contact(),
                new Contact(),
                new Contact(),
                deleteContact
            };

            book.Delete(deleteContact);

            var contactsCount = book.Count();
            Assert.Equal(contactsCount, 3);
            Assert.DoesNotContain(deleteContact,book);
        }

        [Fact]
        public void Delete_LambdaPredicate_AllContactsUpdated()
        {
            var deleteName = "1234";
            var notDeleteName = "13";

            var book = new PhoneBook
            {
                new Contact
                {
                    FirstName = deleteName
                },
                new Contact
                {
                    FirstName = deleteName
                },
                new Contact
                {
                    FirstName = notDeleteName
                }
            };
            
            book.Delete(x => x.FirstName == deleteName);
            
            Assert.Contains(book,x => x.FirstName == notDeleteName);
            Assert.DoesNotContain(book, x => x.FirstName == deleteName);
        }
    }
}
