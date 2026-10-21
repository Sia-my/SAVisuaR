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

            int middle = left + (right - left) / 2;  //가운데 인덱스 계산

            if (middle != right)                     //중앙 요소와 마지막 요소 교환
            {
                RecordSwap(middle, right);          //중앙 요소를 마지막 요소로 이동
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