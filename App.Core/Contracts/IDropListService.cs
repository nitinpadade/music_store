using App.Core.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Contracts
{
    public interface IDropListService
    {
        List<DropComandList> Genres();

        List<DropComandList> Artists();
    }
}
