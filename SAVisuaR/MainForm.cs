using System.Diagnostics;

namespace SAVisuaR
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            TestAlgStepRecording();

        }


        private void TestAlgStepRecording()
        {
            int[] source = { 8, 3, 10, 1, 6, 4, 9, 2, 7, 5 };

            TestAlgStep("Insert",
                new InsertAlgorithm(), new InsertAlgorithm(), source);

            TestAlgStep("Bubble",
                new BubbleAlgorithm(), new BubbleAlgorithm(), source);

            TestAlgStep("Quick",
                new QuickAlgorithm(), new QuickAlgorithm(), source);
        }

        private void TestAlgStep(
            string name,
            Sorter recordSorter,
            Sorter noRecordSorter,
            int[] source)
        {
            // 기록을 켠 상태
            AlgResult onResult = recordSorter.Sort(
                source, "Test", 1, true);

            int expectedCount =
                onResult.ComparisonCount + onResult.SwapCount;

            bool onOK = recordSorter.Steps.Count == expectedCount;

            Debug.WriteLine(
                $"{name} ON: Steps={recordSorter.Steps.Count}, " +
                $"비교+교환={expectedCount}, 확인={onOK}");

            // 기록을 끈 상태
            AlgResult offResult = noRecordSorter.Sort(
                source, "Test", 1, false);

            bool offOK = noRecordSorter.Steps.Count == 0;

            bool countOK =
                onResult.ComparisonCount == offResult.ComparisonCount &&
                onResult.SwapCount == offResult.SwapCount &&
                onResult.MaxRecursionDepth == offResult.MaxRecursionDepth;

            Debug.WriteLine(
                $"{name} OFF: Steps={noRecordSorter.Steps.Count}, " +
                $"확인={offOK}");

            Debug.WriteLine(
                $"{name} ON/OFF 카운터 일치: {countOK}");

            Debug.WriteLine("--------------------------------");
        }
    }
}
