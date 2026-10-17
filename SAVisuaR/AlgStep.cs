using System;
using System.Collections.Generic;
using System.Text;

namespace SAVisuaR
{
    public enum StepType
    {
        Compare,
        Swap
    }

    public class AlgStep
    {
        public StepType Type { get; private set; }
        public int FirstIndex { get; private set; }
        public int SecondIndex { get; private set; }

        public AlgStep(StepType type, int firstIndex, int secondIndex)
        {
            Type = type;
            FirstIndex = firstIndex;
            SecondIndex = secondIndex;
        }
    }
}
