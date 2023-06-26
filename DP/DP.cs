namespace DSA
{
    public class DP
    {


        public int stairs(int A)
        {
            int[] DP = new int[A+1];
            foreach (int i in DP)
                DP[i] = -1;

            DP[0] = 1;

            DP[1] = 1;

            for(int i = 2; i < DP.Count(); i++)
            {
                DP[i] = DP[i - 1] + DP[i - 2];
                    
            }

            return DP[A];

        }


        public class FractionalKnapsackPair : IComparable<FractionalKnapsackPair>
        {
            public decimal UnitWeight { get; set; }

            public int Index { get; set; }

            public FractionalKnapsackPair(decimal unitWeight, int index)
            {
                UnitWeight = unitWeight;
                Index = index;
            }
            public int CompareTo(FractionalKnapsackPair obj)
            {
                if (this.UnitWeight < obj.UnitWeight)
                    return 1;
                else if (obj.UnitWeight < this.UnitWeight)
                    return -1;
                else
                    return 0;
            }
        }
        public int fractionalknapsack(List<int> A, List<int> B, int C)
        {
           decimal happiness = 0;
           List<int> H = new List<int>();
           List<int> W = new List<int>();
           int capacity = C;
           H = A;
           W = B;


            List<FractionalKnapsackPair> K = new List<FractionalKnapsackPair>();
            for(int i = 0; i < B.Count; i++)
            {
                decimal h = H[i];
                decimal w = W[i];

                decimal unitVal = h / w;

                FractionalKnapsackPair fractionalKnapsack = new FractionalKnapsackPair(unitVal, i);
                K.Add(fractionalKnapsack);
            }
            K.Sort();
            for(int i = 0; i < K.Count; i++)
            {
                if (C <= 0) break;
                if (B[K[i].Index] <= capacity)
                {
                    capacity = capacity   - W[K[i].Index];
                    happiness = happiness + H[K[i].Index];
                }
                else
                {
                                   
                    happiness = happiness + (K[i].UnitWeight * capacity);
                    capacity = 0;
                }
            }
            decimal finalAnswer = happiness * 100;
            return  Convert.ToInt32(Math.Floor(finalAnswer));
        }
    }

   
}