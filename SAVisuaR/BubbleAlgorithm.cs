namespace SAVisuaR
{
    public class BubbleAlgorithm : Sorter
    {
        protected override void SortCore()
        {
            for (int i = 0; i < Items.Length - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < Items.Length - 1 - i; j++)
                {
                    RecordComparison(j, j + 1);

                    if (Items[j] > Items[j + 1])
                    {
                        RecordSwap(j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }
    }
}