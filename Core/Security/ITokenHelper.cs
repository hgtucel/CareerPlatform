using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
