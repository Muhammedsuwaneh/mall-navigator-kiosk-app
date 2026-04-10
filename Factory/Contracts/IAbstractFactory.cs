using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Factory.Contracts
{
    public interface IAbstractFactory<T> where T : class
    {
        T Create();
    }
}
