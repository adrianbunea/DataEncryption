using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction.Predictors
{
    class jpegLSPredictor : IPredictor
    {
        public byte Predict(Block block)
        {
            byte result;
            if (block.c >= Math.Max(block.a, block.b))
            {
                result = Math.Min(block.a, block.b);
            }
            else if (block.c <= Math.Min(block.a, block.b))
            {
                result = Math.Max(block.a, block.b);
            }
            else
            {
                result = (byte)(block.a + block.b - block.c);
            }
            return Helpers.Normalize(result);
        }
    }
}
