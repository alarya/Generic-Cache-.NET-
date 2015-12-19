using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCache
{
    public interface ICacheable
    {
        Boolean isExpired();

        Object getIdentifier();

    }
}
