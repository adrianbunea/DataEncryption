using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class APredictor : IPredictor
    {
        public byte Predict(Block block)
        {
            return Helpers.Normalize(block.a);
        }
    }
}
