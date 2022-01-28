using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellingCorrector
{
    public class BloomFilter
    {
        public bool AddItemHash(string item, byte[] bloomFilter)
        {
            if (CheckIsExist(item, bloomFilter))
            {
                return false;
            }
            else
            {
                int hash = Hash(item) & 0x7FFFFFFF;
                byte bit= (byte)(1 << (hash & 7));
                bloomFilter[hash % bloomFilter.Length] = bit;
                return true;
            }
        }
        public static bool CheckIsExist(string item, byte[] bloomFilter)
        {
            
            int hash = Hash(item) & 0x7FFFFFFF;
            byte bit = (byte)(1 << (hash & 7));
            return (bloomFilter[hash % bloomFilter.Length] & bit) != 0;
        }
       public static int Hash(string item)
        {
            int result =17;
            for (int i = 0; i < item.Length; i++)
            {
                unchecked
                {
                    result *= item[i];
                }
            }

            return result;
        }
    }
}
