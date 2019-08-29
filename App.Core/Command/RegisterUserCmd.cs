using App.Core.CommandModels;
using App.Core.Contracts;
using App.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Core.Command
{
    public class RegisterUserCmd : ICrudService<RegisterUser>, IDisposable
    {
        public readonly MusicStoreDataContext _dbContext;
        bool disposed = false;

        public RegisterUserCmd(MusicStoreDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(RegisterUser model)
        {
            var userModel = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Mobile = model.Mobile,
                Email = model.Email,
                Password = model.Password,
                RoleId = 2
            };

            using (TransactionScope tScope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _dbContext.Users.Add(userModel);
                    _dbContext.SaveChanges();
                    tScope.Complete();
                }
                catch (Exception ex)
                {
                   throw ex;
                }
            }

        }

        public void Update(RegisterUser model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
