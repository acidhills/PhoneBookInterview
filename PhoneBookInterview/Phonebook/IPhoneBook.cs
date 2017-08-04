using System;
using System.Collections.Generic;
using PhoneBookInterview.Entities;

namespace PhoneBookInterview.Phonebook
{
    public interface IPhoneBook : IEnumerable<Contact>
    {
        IPhoneBook Add(Contact contact);

        IPhoneBook AddRange(IEnumerable<Contact> range);

        IPhoneBook Update(Func<Contact, bool> predicate, Contact newEntity);

        IPhoneBook Update(Func<Contact, bool> predicate, Func<Contact,Contact> updateFunc);

        IPhoneBook Delete(Func<Contact, bool> predicate);

        IPhoneBook Delete(Contact contact);
    }
}
