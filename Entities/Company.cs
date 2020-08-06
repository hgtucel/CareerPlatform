using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Company: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
