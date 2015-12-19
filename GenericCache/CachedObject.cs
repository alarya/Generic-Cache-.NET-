using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCache
{
    public class CachedObject : ICacheable
    {
        private DateTime dateOfExpiration ;
        private Object identifier = null;
        private Object cacheObject = null ;

       /*
        * obj - The cached object
        * id - Unique identifier that distinguishes the obj param from all other objects residing in the cache
        * minutesToLive - The number of minutes the obj parameter is valid in the cache
        */
        public CachedObject(Object obj, Object id, int minutesToLive)
        {
            this.cacheObject = obj;
            this.identifier = id;
            if(minutesToLive != 0)
            {
                this.dateOfExpiration = DateTime.Now.AddMinutes(minutesToLive);
            }
        }

        public Boolean isExpired()
        {
            if (this.dateOfExpiration != null)
            {
                if (this.dateOfExpiration.CompareTo(DateTime.Now) > 0 )
                {
                    return false;
                }
                else
                {
                    Console.Out.WriteLine("\n{0}: Cache Expired \n",this.identifier);
                    return true;
                }
            }
            else
                return false;  //always false if date of expiration not set

        }

        public Object getIdentifier()
        {
            return identifier;
        }
    }
}
