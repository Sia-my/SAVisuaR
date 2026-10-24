using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SAVisuaR
{
    public class ChangeAnimate
    {
        private BarGraph graph;
        private IReadOnlyList<AlgStep> steps;
        private int stepIndex;

        private System.Windows.Forms.Timer timer;

        private int compareCount;
        private int swapCount;

        public bool IsRunning
        {
            get { return timer.Enabled; }
        }

        public int CompareCount
        {
            get { return compareCount; }
        }

        public int SwapCount
        {
            get { return swapCount; }
        }

        public event EventHandler Finished;

        public ChangeAnimate(BarGraph graph)
        {
            this.graph = graph;
            steps = new List<AlgStep>();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 250;
            timer.Tick += OnTick;
        }

        public void Start(
            int[] source,
            IReadOnlyList<AlgStep> recordedSteps)
        {
            Stop();

            graph.SetData(source);

            steps = recordedSteps;
            stepIndex = 0;

            compareCount = 0;
            swapCount = 0;

            if (steps.Count == 0)
            {
                FinishPlayback();
                return;
            }

            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            graph.ClearHighlight();
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (stepIndex >= steps.Count)
            {
                FinishPlayback();
                return;
            }

            ApplyStep(steps[stepIndex]);

            stepIndex++;
        }

        private void ApplyStep(AlgStep step)
        {
            if (step.Type == StepType.Compare)
            {
                graph.SetHighlight(
                    step.FirstIndex,
                    step.SecondIndex,
                    StepType.Compare);

                compareCount++;
            }
            else if (step.Type == StepType.Swap)
            {
                graph.SetHighlight(
                    step.FirstIndex,
                    step.SecondIndex,
                    StepType.Swap);

                graph.Swap(
                    step.FirstIndex,
                    step.SecondIndex);

                swapCount++;
            }
        }

        private void FinishPlayback()
        {
            timer.Stop();
            graph.ClearHighlight();

            if (Finished != null)
            {
                Finished(this, EventArgs.Empty);
            }
        }
    }
}