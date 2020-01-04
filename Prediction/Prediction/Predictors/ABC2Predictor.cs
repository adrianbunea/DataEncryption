using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class ABC2Predictor : IPredictor
    {
        public byte Predict(Block block)
        {
            return Helpers.Normalize((block.a + (block.b - block.c)) / 2);
        }
    }
}
