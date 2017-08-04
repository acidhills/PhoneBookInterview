using System;
using System.IO;
using MessagePack;
using MessagePack.Resolvers;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Persist
{
    public class MessagePackPhoneBookImporter : IPhonebookImporter
    {
        public T Import<T>(Stream stream) where T : class, IPhoneBook, new()
        {
            if (!stream.CanRead)
                throw new ArgumentException("stream is not availible to read");
            var result = new T();
            while (stream.Length != stream.Position)
            {
                result.Add(MessagePackSerializer.Deserialize<Contact>(stream, ContractlessStandardResolver.Instance, true));
            }
            return result;

        }
    }
}
