using System;


namespace PhotoEnhancer
{
    public interface IFilter
    {
        Photo Process(Photo original, double[] parametrs);
        ParametrInfo[] GetParametersInfo();
    }
}
