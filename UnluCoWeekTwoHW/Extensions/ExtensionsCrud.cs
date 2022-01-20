using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCoWeekTwoHW.Extensions
{
    public static class ExtensionsCrud
    {
        // Bir öğe eklenirken varmı yokmu kontrol eden extension method u yazdık.
        public static bool AddIfNotExists<T>(this ICollection<T> itemCollection, T item)
        {
            if(!itemCollection.Contains(item))
            {
                itemCollection.Add(item);
                return true;
            }
            return false;
            
        }
        // Bloom Filter extension method u yazdık.
        public static void BloomFilterExtensions<T>(this ICollection<T> itemCollection, T item)
        {

        }
    }
}
