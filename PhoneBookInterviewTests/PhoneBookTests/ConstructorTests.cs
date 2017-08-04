using System.Linq;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;
using Xunit;

namespace PhoneBookInterviewTests.PhoneBookTests
{
    public class ConstructorTests
    {
        [Fact]
        public void Constructor_withphonebook_Success()
        {

            var book = new PhoneBook();
            var contact = new Contact();
            book.Add(contact);

            var newbook = new PhoneBook(book);

            Assert.Equal(book.First(), newbook.First());
        }
    }
}
