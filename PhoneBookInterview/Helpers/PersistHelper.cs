
using System.IO;
using PhoneBookInterview.Persist;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Helpers
{
    public static class PersistHelper
    {
        private static IPhonebookExporter _exporter = new MessagePackPhoneBookExporter();

        private static IPhonebookImporter _importer = new MessagePackPhoneBookImporter();
        public static void Export(this IPhoneBook book, FileStream stream ,IPhonebookExporter exporter = null)
        {
            exporter = exporter ?? _exporter;
            exporter.Export(stream, book);
        }
        public static void Import(this IPhoneBook book, FileStream stream, IPhonebookImporter importer = null)
        {
            importer = importer ?? _importer;
            var newBook = importer.Import<PhoneBook>(stream);
            book.AddRange(newBook);
        }
    }
}
