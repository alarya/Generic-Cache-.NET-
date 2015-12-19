using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GenericCache
{
    class TestCache
    {
        static void Main(string[] args)
        {
            String obj = "ABCDEFGHIJKLMNO";
            CachedObject co = new CachedObject(obj, "1234", 1);

            Console.Out.WriteLine("Added cache object: 1234\n");
            CacheManager.putCache(co);


            Console.Out.WriteLine("Searching cache object: 1234\n");
            CachedObject o = (CachedObject)CacheManager.getCache("1234");

            if (o == null)
            {
                Console.Out.WriteLine("\n1234: Could not find cache object\n");
            }
            else
                Console.Out.WriteLine("\n{0}: Found Cache Object\n", o.getIdentifier());

            Thread.Sleep(70000);

            Console.Out.WriteLine("Searching cache object: 1234\n");
            o = (CachedObject)CacheManager.getCache("1234");

            if (o == null)
            {
                Console.Out.WriteLine("\n1234: Could not find cache object\n");
            }
            else
                Console.Out.WriteLine("\n{0}: Found Cache Object\n",o.getIdentifier());

            Console.ReadKey();
        }
    }
}
