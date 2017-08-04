using System.Linq;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;
using Xunit;

namespace PhoneBookInterviewTests.PhoneBookTests
{
    public class AddTests
    {
        [Fact]
        public void Add_Contact_Success()
        {
            var book = new PhoneBook();
            var contact = new Contact();

            book.Add(contact);

            Assert.Equal(book.First(), contact);
        }

        [Fact]
        public void AddRange_ArrayContact_Success()
        {
            var book = new PhoneBook();
            var contacts = new[] {new Contact(), new Contact()};

            book.AddRange(contacts);

            Assert.Equal(book.First(), book.First());
            Assert.Equal(book.Last(), book.Last());
            Assert.NotEqual(book.Last(), book.First());
        }

    }
}
