using App.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface ICartService
    {
        int CartCount(int userId, string cartId);

        void ClearCart(int userId, string cartId);

        List<CartDetails> ViewCart(int userId, string cartId);

        void RemoveFromCart(int recordId);
    }
}
