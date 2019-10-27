using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter
{
    public static class GuardClauses
    {
        public static void IsNotGreaterThan32(int argument)
        {
            if (argument > 32)
            {
                throw new ArgumentException("Value cannot be greater than 32!");
            }
        }

        public static void IsNotLesserThan1(int argument)
        {
            if (argument < 1)
            {
                throw new ArgumentException("Value cannot be lesser than 1!");
            }
        }
    }
}
