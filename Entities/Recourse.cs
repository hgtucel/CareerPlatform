using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Recourse: IEntity
    {
        public int Id { get; set; }
        public DateTime RecourseDate { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}
