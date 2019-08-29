using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface ICrudService<T>
    {
        void Save(T model);

        void Update(T model);

        void Delete(int id);
    }
}
