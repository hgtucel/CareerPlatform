using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CompanyListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }
    }
}
