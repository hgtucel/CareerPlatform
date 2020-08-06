using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Advert: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string City { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Recourse> Recourses { get; set; }

    }
}
