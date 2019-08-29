using App.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface IAuthenticateService
    {
        void SetUserData(UserInfo obj);

        void ClearUserData();
    }
}
