using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class AdvertUpdateDto: IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
    }
}
