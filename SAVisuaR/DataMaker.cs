using System;

namespace SAVisuaR
{
    public class DataMaker
    {
        private readonly Random random = new Random();

        public int[] MakeSorted(int n)
        {
            CheckSize(n);

            int[] data = new int[n];

            for (int i = 0; i < n; i++)
            {
                data[i] = i + 1;
            }

            return data;
        }

        public int[] MakeReverse(int n)
        {
            CheckSize(n);

            int[] data = new int[n];

            for (int i = 0; i < n; i++)
            {
                data[i] = n - i;
            }

            return data;
        }

        public int[] MakeRandom(int n)
        {
            int[] data = MakeSorted(n);

            for (int i = data.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);

                int temp = data[i];
                data[i] = data[j];
                data[j] = temp;
            }

            return data;
        }

        public int[] MakeExample()
        {
            return new int[] { 8, 3, 10, 1, 6, 4, 9, 2, 7, 5 };
        }

        private void CheckSize(int n)
        {
            if (n < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
        }
    }
}