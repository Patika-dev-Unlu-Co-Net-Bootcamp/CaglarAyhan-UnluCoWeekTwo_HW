using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekTwoHW.Extensions
{
    public static class ProbabilisticSearcingExtensions
    {
        public static bool addNewUser (this IEnumerable<string> _bloomFilter, string name)
        {
            AddItemHashing(name);
            return true;
        }
        private static byte[] _bloomFilter = new byte[1000];
        static bool AddItemHashing(string item)
        {
            if (CheckExists(item))
            {
                return false;
            }
            else
            {
             int hash = Hash(item) & 0x7FFFFFFF; // bit olarak işaretliyorum.
             byte bit = (byte)(1 << (hash & 7)); 
             _bloomFilter[hash % _bloomFilter.Length] |= bit;
                return true;
            }
        }

        static bool CheckExists(string item)
        {
            int hash = Hash(item) & 0x7FFFFFFF;
            byte bit = (byte)(1 << (hash & 7)); 
            return (_bloomFilter[hash % _bloomFilter.Length] & bit) != 0;
        }
        private static int Hash(string item)// hash algoritmam.
        {
            int result = 17;
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
