using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class AB2Predictor : IPredictor
    {
        public byte Predict(Block block)
        {
            return Helpers.Normalize((block.a + block.b) / 2);
        }
    }
}
