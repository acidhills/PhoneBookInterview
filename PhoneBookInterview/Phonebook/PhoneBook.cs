using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PhoneBookInterview.Entities;

namespace PhoneBookInterview.Phonebook
{
    public class PhoneBook: IPhoneBook
    {
        
        private List<Contact> _contacts = new List<Contact>();

        public PhoneBook()
        {
        }
        
        public PhoneBook(IPhoneBook phoneBook)
        {
            AddRange(phoneBook);
        }

        public IEnumerator<Contact> GetEnumerator()
        {
            return _contacts.OrderBy(x => x.FirstName + x.LastName).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IPhoneBook Add(Contact contact)
        {
            _contacts.Add(contact);
            return this;
        }

        public IPhoneBook AddRange(IEnumerable<Contact> range)
        {
            _contacts.AddRange(range);
            return this;
        }

        public IPhoneBook Update(Func<Contact, bool> predicate, Contact newEntity)
        {
            Update(predicate, x => newEntity);
            return this;
        }

        public IPhoneBook Update(Func<Contact, bool> predicate, Func<Contact, Contact> updateFunc)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                var current = _contacts[i];
                if (predicate(current))
                    _contacts[i] = updateFunc(current);
            }
            return this;
        }

        public IPhoneBook Delete(Func<Contact, bool> predicate)
        {
            var removed = _contacts.Where(predicate).ToList();
            foreach (var contact in removed)
            {
                _contacts.Remove(contact);
            }
            return this;
        }

        public IPhoneBook Delete(Contact contact)
        {
            Delete(x => x == contact);
            return this;
        }
    }
}
