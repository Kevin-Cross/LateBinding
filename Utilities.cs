using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [SpecialClass(3)]
    public static class Utilities
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T swapvar = a;
            a = b;
            b = swapvar;
        }
    }
}
