using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class CPredictor : IPredictor
    {
        public byte Predict(byte a, byte b, byte c)
        {
            return Helpers.Normalize(c);
        }
    }
}
