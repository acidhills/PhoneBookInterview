using System;
using System.IO;
using System.Text;
using PhoneBookInterview.Entities;
using PhoneBookInterview.Phonebook;

namespace PhoneBookInterview.Persist
{
    public class PlainBinaryExporter : IPhonebookExporter
    {
        public void Export(Stream stream, IPhoneBook book)
        {
            if (book == null)
                throw new ArgumentException("phone book should be not null");
            if (stream == null)
                throw new ArgumentException("stream should be not null");
            if (!stream.CanWrite)
                throw new ArgumentException("stream is not availible to write");
            foreach (var contact in book)
            {
                SerializeContact(stream, contact);
            }

        }

        private void SerializeContact(Stream stream, Contact contact)
        {
            var type = BitConverter.GetBytes((int)contact.Type);
            stream.Write(BitConverter.GetBytes(type.Length),0, Constants.IntSize);
            stream.Write(type,0,type.Length);

            WriteString(stream, contact.FirstName);
            WriteString(stream, contact.LastName);
            WriteString(stream, contact.PhoneNumber);
        }

        private void WriteString(Stream stream, string str)
        {
            var byteStr = Encoding.UTF8.GetBytes(str ?? Constants.Null);
            stream.Write(BitConverter.GetBytes(byteStr.Length), 0, Constants.IntSize);
            stream.Write(byteStr, 0, byteStr.Length);
        }
    }
}
