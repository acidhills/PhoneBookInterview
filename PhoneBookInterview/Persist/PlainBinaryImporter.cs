using System;
using System.IO;
using System.Text;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Persist
{
    public class PlainBinaryImporter : IPhonebookImporter
    {
        public T Import<T>(Stream stream) where T : class, IPhoneBook, new()
        {
            if (!stream.CanRead)
                throw new ArgumentException("stream is not availible to read");
            var result = new T();
            while (stream.Length != stream.Position)
            {
                result.Add(DeserializeContact(stream));
            }
            return result;
        }

        private Contact DeserializeContact(Stream stream)
        {
            var buffer = new byte[Constants.IntSize];

            stream.Read(buffer, 0, Constants.IntSize);
            var size = BitConverter.ToInt32(buffer, 0);

            buffer = new byte[size];
            stream.Read(buffer, 0, size);
            var type = (ContactType) BitConverter.ToInt32(buffer, 0);
            var fstName = GetStringFromStream(stream);
            var lstName = GetStringFromStream(stream);
            var number = GetStringFromStream(stream);

            return new Contact
            {
                FirstName = fstName,
                LastName = lstName,
                PhoneNumber = number,
                Type = type
            };
        }

        private string GetStringFromStream(Stream stream)
        {
            var buffer = new byte[Constants.IntSize];
            stream.Read(buffer, 0, Constants.IntSize);
            var size = BitConverter.ToInt32(buffer, 0);

            buffer = new byte[size];
            stream.Read(buffer, 0, size);
            var resultStr = Encoding.UTF8.GetString(buffer);
            return resultStr == Constants.Null ? null : resultStr;
        }
    }
}
