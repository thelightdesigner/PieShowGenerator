using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShowGenerator
{
    public struct Color(byte r, byte g, byte b)
    {
        public byte R = r, G = g, B = b;
    }
}
