using System;

using System.Collections.Generic;
using System.Text;

namespace SAVisuaR
{
    public class AlgResult
    {
        public string AlgorithmName { get; private set; }
        public string DataType { get; private set; }
        public int N { get; private set; }
        public int Repetition { get; private set; }
        public int ComparisonCount { get; private set; }
        public int SwapCount { get; private set; }
        public int MaxRecursionDepth { get; private set; }

        public AlgResult(
            string algorithmName,
            string dataType,
            int n,
            int repetition,
            int comparisonCount,
            int swapCount,
            int maxRecursionDepth)
        {
            AlgorithmName = algorithmName;
            DataType = dataType;
            N = n;
            Repetition = repetition;
            ComparisonCount = comparisonCount;
            SwapCount = swapCount;
            MaxRecursionDepth = maxRecursionDepth;
        }
    }
}
