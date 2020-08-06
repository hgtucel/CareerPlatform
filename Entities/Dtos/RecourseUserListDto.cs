using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RecourseUserListDto: IDto
    {
        public int Id { get; set; }
        public DateTime RecourseDate { get; set; }
        public int AdvertId { get; set; }
        public string AdvertTitle { get; set; }

    }
}
