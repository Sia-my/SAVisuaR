namespace SAVisuaR
{
    public class QuickAlgorithm : Sorter
    {
        protected override void SortCore()
        {
            QuickSort(0, Items.Length - 1, 1);
        }

        private void QuickSort(int left, int right, int depth)
        {
            if (left > right)
            {
                return;
            }

            UpdateMaxRecursionDepth(depth);

            if (left == right)
            {
                return;
            }

            int pivot = Items[right];
            int boundary = left;

            for (int i = left; i < right; i++)
            {
                RecordComparison(i, right);

                if (Items[i] <= pivot)
                {
                    if (i != boundary)
                    {
                        RecordSwap(i, boundary);
                    }

                    boundary++;
                }
            }

            if (boundary != right)
            {
                RecordSwap(boundary, right);
            }

            QuickSort(left, boundary - 1, depth + 1);
            QuickSort(boundary + 1, right, depth + 1);
        }
    }
}