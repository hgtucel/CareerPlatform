using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Profile: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
