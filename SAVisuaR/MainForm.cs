using System.Diagnostics;

namespace SAVisuaR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TestQuickSort(); // 임시 테스트

        }

        private bool IsSorted(int[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i - 1] > data[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void TestQuickSort()
        {
            DataMaker maker = new DataMaker();

            // 정렬된 데이터 10,000개 테스트
            int[] sorted = maker.MakeSorted(10000);
            QuickAlgorithm quick1 = new QuickAlgorithm();

            AlgResult result1 =
                quick1.Sort(sorted, "Sorted", 1, false);

            Debug.WriteLine(
                $"정렬 데이터: 비교={result1.ComparisonCount}, " +
                $"교환={result1.SwapCount}, " +
                $"재귀 깊이={result1.MaxRecursionDepth}");

            // 역순 데이터 10,000개 테스트
            int[] reverse = maker.MakeReverse(10000);
            QuickAlgorithm quick2 = new QuickAlgorithm();

            AlgResult result2 =
                quick2.Sort(reverse, "Reverse", 1, false);

            Debug.WriteLine("정렬 여부: " + IsSorted(quick1.SortedArray));

            Debug.WriteLine(
                $"역순 데이터: 비교={result2.ComparisonCount}, " +
                $"교환={result2.SwapCount}, " +
                $"재귀 깊이={result2.MaxRecursionDepth}");
        }
    }
}
