using System;
using System.IO;
using MessagePack;
using MessagePack.Resolvers;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Persist
{
    public class MessagePackPhoneBookExporter : IPhonebookExporter
    {
        public void Export(Stream stream,
                           IPhoneBook book)
        {
            if (book == null)
                throw new ArgumentException("phone book should be not null");
            if (stream == null)
                throw new ArgumentException("stream should be not null");
            if (!stream.CanWrite)
                throw new ArgumentException("stream is not availible to write");
            foreach (var contact in book)
            {
                MessagePackSerializer.Serialize(stream, contact, ContractlessStandardResolver.Instance);
            }
        }
    }
}
