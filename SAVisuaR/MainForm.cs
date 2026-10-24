using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SAVisuaR
{
    public partial class MainForm : Form
    {
        private BarGraph barGraph;
        private DataMaker dataMaker = new DataMaker();
        private ChangeAnimate changeAnimate;
        private int[] expectedArray;
        private int expectedCompareCount;
        private int expectedSwapCount;
        public MainForm()
        {
            InitializeComponent();

            SetupBarGraphTest();

        }


        private void SetupBarGraphTest()
        {
            barGraph = new BarGraph();

            barGraph.Location = new Point(20, 20);
            barGraph.Size = new Size(700, 300);
            barGraph.Anchor =
                AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(barGraph);

            changeAnimate = new ChangeAnimate(barGraph);
            changeAnimate.Finished += ChangeAnimate_Finished;

            barGraph.SetData(dataMaker.MakeRandom(20));

            Button compareButton = new Button();
            compareButton.Text = "비교 강조";
            compareButton.Location = new Point(20, 340);
            compareButton.Size = new Size(100, 30);
            compareButton.Click += CompareButton_Click;
            Controls.Add(compareButton);

            Button swapButton = new Button();
            swapButton.Text = "교환";
            swapButton.Location = new Point(130, 340);
            swapButton.Size = new Size(100, 30);
            swapButton.Click += SwapButton_Click;
            Controls.Add(swapButton);

            Button clearButton = new Button();
            clearButton.Text = "강조 해제";
            clearButton.Location = new Point(240, 340);
            clearButton.Size = new Size(100, 30);
            clearButton.Click += ClearButton_Click;
            Controls.Add(clearButton);

            Button playButton = new Button();
            playButton.Text = "삽입 정렬 재생";
            playButton.Location = new Point(350, 340);
            playButton.Size = new Size(130, 30);
            playButton.Click += PlayButton_Click;

            Controls.Add(playButton);
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            barGraph.SetHighlight(2, 3, StepType.Compare);
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            barGraph.Swap(2, 3);
            barGraph.SetHighlight(2, 3, StepType.Swap);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            barGraph.ClearHighlight();
        }

        private void ChangeAnimate_Finished(object sender, EventArgs e)
        {
            Debug.WriteLine("애니메이션 재생 완료");
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            int[] source = dataMaker.MakeExample();

            InsertAlgorithm sorter = new InsertAlgorithm();

            sorter.Sort(source, "Example", 1, true);

            changeAnimate.Start(source, sorter.Steps);
        }
    }
}
