using System.IO;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Persist
{
    public interface IPhonebookImporter
    {
        T Import<T>(Stream stream) where T: class, IPhoneBook, new();
    }
}
