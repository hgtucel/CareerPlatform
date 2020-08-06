using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User: IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public Company Company { get; set; }
        public IEnumerable<Advert> Adverts { get; set; }
        public Profile Profile { get; set; }
        public IEnumerable<Recourse> Recourses { get; set; }
    }
}
