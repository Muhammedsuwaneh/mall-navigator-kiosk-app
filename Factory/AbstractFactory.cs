using MallMapKiosk.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Factory
{
    public class AbstractFactory<T> : IAbstractFactory<T> where T : class
    {
        public T Create()
        {
            throw new NotImplementedException();
        }
    }
}
