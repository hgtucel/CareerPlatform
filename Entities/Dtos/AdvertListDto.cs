using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class AdvertListDto: IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyTitle { get; set; }
    }
}
