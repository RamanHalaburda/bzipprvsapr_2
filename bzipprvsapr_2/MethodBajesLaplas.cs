using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzipprvsapr_2
{
    class MethodBajesLaplas
    {
        static public Double[] getMinArray(UInt16[,] _m, Double[] _q)
        {
            Double[] arr = new Double[_m.GetLength(0)];
            Double sum = 0F;
            for (int i = 0; i < _m.GetLength(0); ++i)
            {
                sum = 0F;
                for (int j = 0; j < _m.GetLength(1); ++j)
                {
                        sum += _m[i, j] * _q[j];
                }
                arr[i] = sum;
            }

            return arr;
        }

        static public Double getMaxValue(Double[] _arr)
        {
            Double max = _arr[0];
            for (int i = 1; i < _arr.GetLength(0); ++i)
            {
                if (_arr[i] > max)
                    max = _arr[i];
            }

            return max;
        }
    }
}
