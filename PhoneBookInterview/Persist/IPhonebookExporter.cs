using System.IO;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Persist
{
    public interface IPhonebookExporter
    {
        void Export(Stream stream, IPhoneBook book);
    }
}
