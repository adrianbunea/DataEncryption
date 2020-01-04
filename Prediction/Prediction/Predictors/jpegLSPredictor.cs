using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class jpegLSPredictor : IPredictor
    {
        public byte Predict(byte a, byte b, byte c)
        {
            byte result;
            if (c >= Math.Max(a, b))
            {
                result = Math.Min(a, b);
            }
            else if (c <= Math.Min(a, b))
            {
                result = Math.Max(a, b);
            }
            else
            {
                result = (byte)(a + b - c);
            }
            return Helpers.Normalize(result);
        }
    }
}
