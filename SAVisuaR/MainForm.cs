using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SAVisuaR
{
    public partial class MainForm : Form
    {
        private BarGraph barGraph;
        private DataMaker dataMaker = new DataMaker();
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
    }
}
