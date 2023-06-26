namespace DSA
{



    public class Greedy
    {
        class Pair : IComparable<Pair>
        {
            public int? Start { get; set; }

            public int? End { get; set; }

            public Pair(int start, int end)
            {
                Start = start;
                End = end;
            }

            public int CompareTo(Pair other)
            {
                if (this.End > other.End)
                    return 1;
                else if (other.End > this.End)
                    return -1;
                else
                    return 0;
            }


        }

        public int finishMaximumJobs(List<int> A, List<int> B)
        {
            List<Pair> result = new List<Pair>();
            for (int i = 0; i < A.Count; i++)
            {
                Pair p = new Pair(A[i], B[i]);
                result.Add(p);
            }

            result.Sort();
            A.Clear();
            B.Clear();


            int ans = 1;
            int last_End = B[0];
            for (int i = 0; i < B.Count; i++)
            {
                if (A[i] >= last_End)
                {
                    ans++;
                    last_End = B[i];
                }
            }

            return ans;
        }
        //{ 1,6,3,1,10,12,20,5,2};
        public int candy(List<int> A)
        {
            int finalAnser = 0;

            List<int> B = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                B.Add(1);
            }


            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] > A[i - 1] && B[i] <= B[i - 1])
                {
                    B[i] = 1 + B[i - 1];
                }
            }


            for (int i = A.Count - 2; i >= 0; i--)
            {
                if (A[i] > A[i + 1] && B[i] <= B[i + 1])
                {
                    B[i] = 1 + B[i + 1];
                }
            }


            for (int i = 0; i < B.Count; i++)
            {
                finalAnser = finalAnser + B[i];
            }


            return finalAnser;


        }



    }
}






























































































































































































































































































































