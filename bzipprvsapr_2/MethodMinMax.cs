using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bzipprvsapr_2
{
    class MethodMinMax
    {
        static public UInt16[] getMinArray(UInt16[,] _m)
        {
            UInt16[] arr = new UInt16[_m.GetLength(0)];

            for (int i = 0; i < _m.GetLength(0); ++i)
            {
                UInt16 min = _m[i,0];
                for (int j = 1; j < _m.GetLength(1); ++j)
                {
                    if (_m[i, j] < min)
                        min = _m[i, j];
                }
                arr[i] = min;
            }

            return arr;
        }

        static public UInt16 getMaxValue(UInt16[] _arr)
        {
            UInt16 max = _arr[0];
            for (int i = 1; i < _arr.GetLength(0); ++i)
            {
                if (_arr[i] > max)
                    max = _arr[i];
            }
            
            return max;
        }
    }
}
