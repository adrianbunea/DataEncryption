using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction
{
    static class Helpers
    {
        public static byte Normalize(int value)
        {
            return (byte)(value < 0 ? 0 : (value > 255 ? 255 : value));
        }
    }
}
