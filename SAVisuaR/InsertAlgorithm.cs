namespace SAVisuaR
{
    public class InsertAlgorithm : Sorter
    {
        protected override void SortCore()
        {
            for (int i = 1; i < Items.Length; i++)
            {
                int j = i;

                while (j > 0)
                {
                    RecordComparison(j - 1, j);

                    if (Items[j - 1] <= Items[j])
                    {
                        break;
                    }

                    RecordSwap(j - 1, j);
                    j--;
                }
            }
        }
    }
}