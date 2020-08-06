using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public class AuthorHelper
    {
        public static bool OwnerAccess(int userId, int reqUserId)
        {
            if(reqUserId != userId)
            {
                return false;
            }

            return true;
        }
    }
}
