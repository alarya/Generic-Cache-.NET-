using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GenericCache
{
    public class CacheManager
    {
        /* A Dictionary that contatins all objects in the cache */
        private static Dictionary<Object,ICacheable> cacheDictionary= new Dictionary<Object,ICacheable>();
        private static bool backgroundCleanupTaskCreated = false;
        
        
        static CacheManager()
        {
            //create a background thread for purging
            if (!backgroundCleanupTaskCreated)
            {
                Task.Run(cleanupTask);
                backgroundCleanupTaskCreated = true;
            }
        
        }

        static async Task cleanupTask()
        {
            while(true)
            {
                Console.Out.WriteLine("\nCleanup thread: Checking cache objects..\n");
                //purge expired cache objects
                IEnumerable<Object> keys = cacheDictionary.Keys;

                foreach(Object key in keys)
                {
                    if (cacheDictionary.ContainsKey(key))
                    {
                        ICacheable cacheObject = cacheDictionary[key] ;

                        if(cacheObject.isExpired())
                        {
                            Console.Out.WriteLine("\n{0}: Cleanup cache object\n", cacheObject.getIdentifier());
                            cacheDictionary.Remove(key);
                        }
                    }
                }

                //repeat after every 10 secs
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        public static void putCache(ICacheable obj)
        {
            cacheDictionary[obj.getIdentifier()] = obj ; 
        }

        public static ICacheable getCache(Object identifier)
        {
            if (cacheDictionary.ContainsKey(identifier))
            {
                if (!cacheDictionary[identifier].isExpired())
                {
                    return cacheDictionary[identifier];
                }
                else
                {
                    cacheDictionary.Remove(identifier);
                    return null;
                }
            }
            else
                return null;
        }
    }
}
