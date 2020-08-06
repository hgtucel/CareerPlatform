﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserListDto: IDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
