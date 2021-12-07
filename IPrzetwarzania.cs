using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_sa
{
    interface IPrzetwarzania
    {
        string Name { get; }
        int Id { get; }
        public void Run(IFunction function, decimal rangeFrom, decimal rangeTo, string name);
    }
}
