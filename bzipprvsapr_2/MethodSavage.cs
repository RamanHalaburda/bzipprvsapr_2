using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bzipprvsapr_2
{
    class MethodSavage
    {
        static public Int16[,] getMatrixCoefficient(UInt16[,] _m)
        {
            Int16[,] arr = new Int16[_m.GetLength(0),_m.GetLength(1) + 1];
            
            // search max value in each column
            UInt16[] maxArr = new UInt16[_m.GetLength(1)];
            for (int i = 0; i < _m.GetLength(1); ++i)
            {
                UInt16 max = _m[0, i];
                for (int j = 1; j < _m.GetLength(0); ++j)
                {
                    if (_m[j, i] > max)
                        max = _m[j, i];
                }
                maxArr[i] = max;
            }

            // get coefficients
            for (int i = 0; i < _m.GetLength(0); ++i)
            {
                for (int j = 0; j < _m.GetLength(1); ++j)
                {
                    arr[i, j] = (Int16)(maxArr[j] - _m[i, j]);
                }
            }

            // search max value in each row
            for (int i = 0; i < _m.GetLength(0); ++i)
            {
                Int16 max = arr[i, 0];
                for (int j = 1; j < _m.GetLength(1); ++j)
                {
                    if (arr[i, j] > max)
                        max = arr[i, j];
                }
                arr[i, arr.GetLength(1) - 1] = max;
            }

            return arr;
        }

        static public Int16 getMaxValue(Int16[,] _arr)
        {
            Int16 max = _arr[0,_arr.GetLength(1) - 1];
            for (int i = 1; i < _arr.GetLength(0); ++i)
            {
                if (_arr[i, _arr.GetLength(1) - 1] > max)
                    max = _arr[i, _arr.GetLength(1) - 1];
            }

            return max;
        }
    }
}
