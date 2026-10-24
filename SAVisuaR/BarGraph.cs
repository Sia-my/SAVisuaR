
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SAVisuaR
{
    public class BarGraph : Panel
    {
        private int[] values = new int[0];
        private int maxValue = 0;

        private int firstIndex = -1;
        private int secondIndex = -1;

        private StepType highlightType;

        private Color barColor = Color.SteelBlue;
        private Color compareColor = Color.Gold;
        private Color swapColor = Color.IndianRed;

        public BarGraph()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public void SetData(int[] data)
        {
            if (data == null)
            {
                values = new int[0];
            }
            else
            {
                values = (int[])data.Clone();
            }

            maxValue = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > maxValue)
                {
                    maxValue = values[i];
                }
            }

            firstIndex = -1;
            secondIndex = -1;

            Invalidate();
        }

        public void SetHighlight(
            int first,
            int second,
            StepType type)
        {
            if (first < 0 || first >= values.Length ||
                second < 0 || second >= values.Length)
            {
                ClearHighlight();
                return;
            }

            firstIndex = first;
            secondIndex = second;
            highlightType = type;

            Invalidate();
        }

        public void ClearHighlight()
        {
            firstIndex = -1;
            secondIndex = -1;

            Invalidate();
        }

        public void Swap(int i, int j)
        {
            if (i < 0 || i >= values.Length ||
                j < 0 || j >= values.Length)
            {
                return;
            }

            int temp = values[i];
            values[i] = values[j];
            values[j] = temp;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (values.Length == 0 || maxValue <= 0 ||
                ClientSize.Width <= 0 || ClientSize.Height <= 0)
            {
                return;
            }

            float barWidth = (float)ClientSize.Width / values.Length;
            float gap = 0;

            if (barWidth > 3)
            {
                gap = 1;
            }

            for (int i = 0; i < values.Length; i++)
            {
                float x = i * barWidth;
                float drawWidth = barWidth - gap;

                // 막대가 1픽셀보다 좁아지면 최소 폭을 확보한다.
                if (drawWidth < 1)
                {
                    drawWidth = 1;
                }

                float barHeight =
                    (float)values[i] / maxValue * ClientSize.Height;

                float y = ClientSize.Height - barHeight;

                Color currentColor = barColor;

                if (i == firstIndex || i == secondIndex)
                {
                    if (highlightType == StepType.Compare)
                    {
                        currentColor = compareColor;
                    }
                    else if (highlightType == StepType.Swap)
                    {
                        currentColor = swapColor;
                    }
                }

                using (SolidBrush brush = new SolidBrush(currentColor))
                {
                    e.Graphics.FillRectangle(
                        brush,
                        new RectangleF(x, y, drawWidth, barHeight));
                }
            }
        }
    }
}
