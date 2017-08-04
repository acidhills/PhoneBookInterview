﻿namespace PhoneBookInterview.Entities
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactType Type { get; set; } 
        public string PhoneNumber { get; set; }
    }
}