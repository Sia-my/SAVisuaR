using System;
using System.Collections.Generic;
using System.Text;

namespace SAVisuaR
{
    public abstract class Sorter
    {
        private int[] items = new int[0];

        private int comparisonCount;
        private int swapCount;
        private int maxRecursionDepth;
        private bool recordSteps = true;

        private readonly List<AlgStep> steps =
            new List<AlgStep>();

        public int ComparisonCount
        {
            get { return comparisonCount; }
        }

        public int SwapCount
        {
            get { return swapCount; }
        }

        public int MaxRecursionDepth
        {
            get { return maxRecursionDepth; }
        }

        public IReadOnlyList<AlgStep> Steps
        {
            get { return steps.AsReadOnly(); }
        }

        public int[] SortedArray
        {
            get { return (int[])items.Clone(); }
        }

        protected int[] Items
        {
            get { return items; }
        }

        public AlgResult Sort(
            int[] source,
            string dataType,
            int repetition,
            bool recordSteps = true
            )
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            this.recordSteps = recordSteps;


            Initialize(source);

            SortCore();

            return new AlgResult(
                GetType().Name,
                dataType,
                items.Length,
                repetition,
                comparisonCount,
                swapCount,
                maxRecursionDepth);
        }

        private void Initialize(int[] source)
        {
            items = (int[])source.Clone();

            comparisonCount = 0;
            swapCount = 0;
            maxRecursionDepth = 0;

            steps.Clear();
        }

        protected abstract void SortCore();

        protected void RecordComparison(int firstIndex, int secondIndex)
        {
            comparisonCount++;

            if (recordSteps)
            {
                steps.Add(new AlgStep(
                    StepType.Compare,
                    firstIndex,
                    secondIndex));
            }
        }

        protected void RecordSwap(int firstIndex, int secondIndex)
        {
            swapCount++;

            if (recordSteps)
            {
                steps.Add(new AlgStep(
                    StepType.Swap,
                    firstIndex,
                    secondIndex));
            }

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        protected void UpdateMaxRecursionDepth(int depth)
        {
            if (depth > maxRecursionDepth)
            {
                maxRecursionDepth = depth;
            }
        }
    }
}
