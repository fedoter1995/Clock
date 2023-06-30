using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tools
{
    public static class CustomMath
    {
        public static int Round(float value, int multiplicity)
        {
            var roundValue = System.Math.Round(value / multiplicity) * multiplicity;
            return System.Convert.ToInt32(roundValue);
        }
    }
}

