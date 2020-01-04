using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    interface IPredictor
    {
        byte Predict(byte a, byte b, byte c);
    }
}
