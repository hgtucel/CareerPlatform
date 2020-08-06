using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Category: IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Advert> Adverts { get; set; }
    }
}
