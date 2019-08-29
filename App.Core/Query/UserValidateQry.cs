using App.Core.Contracts;
using App.Core.QueryModels;
using App.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Query
{
    public class UserValidateQry : IUserValidate, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public UserValidateQry(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserInfo Execute(ValidationParameters parameters)
        {
            var hasUser = _dbContext.Users.Where(n => n.Email.Equals(parameters.Email) && n.Password.Equals(parameters.Password)).FirstOrDefault();
            if (hasUser != null)
            {
                var _roles = _dbContext.Roles.ToList();
                return new UserInfo
                {
                    IsAuthenticated = true,
                    Roles = _roles.Select(n => n.Id.ToString()).ToArray(),
                    Name = hasUser.Firstname + " " + hasUser.Lastname,
                    RoleId = hasUser.RoleId,
                    Role = hasUser.Role.Name,
                    Email = hasUser.Email,
                    UserId = hasUser.Id
                };
            }

            return new UserInfo { IsAuthenticated = false };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects here.
                _dbContext.Dispose();
            }

            // Free unmanaged objects here.
            disposed = true;
        }
        
    }
}
