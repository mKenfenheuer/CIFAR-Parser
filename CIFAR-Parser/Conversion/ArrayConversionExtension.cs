using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFARParser.Conversion
{
    public static class ArrayConversionExtension
    {
        public static IEnumerable<IEnumerable<T>> ToRowMajor<T>(this IEnumerable<T> enumerable, int rowLength)
        {
            List<IEnumerable<T>> rows = new List<IEnumerable<T>>();
            for(int offset = 0; offset <= enumerable.Count() - rowLength; offset += rowLength)
            {
                rows.Add(enumerable.Skip(offset).Take(rowLength));
            }
            return rows;
        }
    }
}
