using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_library
{
    internal interface IResponses
    {
        string Symbol { get; set; }

    }
    internal interface IListResponses : IResponses
    {

    }
}
