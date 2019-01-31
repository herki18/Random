using System;
using System.Collections.Generic;
using System.Text;

namespace Random.Api
{
    public interface IRandomGenerator
    {
        int[] RandomIntArray(int size);
    }
}
