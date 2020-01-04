using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class HalfPredictor : IPredictor
    {
        public byte Predict(byte a, byte b, byte c)
        {
            return 128;
        }
    }
}
