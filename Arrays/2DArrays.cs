using System;

namespace DSA
{
    public class _2DArrays
    {

        public static void row_with_maximum_number_of_ones(List<List<int>> A)
        {
            int i = 0;
            int j = A.Count - 1;
            int ans = 0;
            while(i < A.Count && j >= 0)
            {
                while(j >=0 && A[i][j] == 1)
                {
                    j--;
                    ans = i;
                }

                i++;

            }           
        }


        public static void search_in_sorted_array(List<List<int>> A, int B)
        {
            int i = 0;
            int j = A[0].Count - 1;
            int ans = int.MaxValue;
            while(i < A.Count && j >=0)
            {
                if(A[i][j] == B)
                {
                    int _i = i + 1;
                    int _j = j + 1;
                    ans = Math.Min(ans, _i * (1009) + _j);
                }

                if (A[i][j]<B)
                {
                    i++;                    
                }
                else
                {
                    j--;
                }
               
            }


        }


        //  |A[i] > A[j]| & |i > j| - Candidate 1 
        //  (A[i] - A[j])  +(i - j) 
        //  (A[i] + i) - (A[j] + j)
        //  (A[i] + i) - (A[j] + j)
        
        //  |A[i] > A[j]| & |i<j| - Candidate 2
        //  (A[i] - A[j])  -(i + j) 
        //  (A[i] - i) - (A[j] - j)
        //  (A[i] - i) - (A[j] - j)
        //  (A[i] - i) - (A[j] - j)  
        public static void maximizeabsolutedifference(List<int> A)
        {
            int maxValue1 = int.MinValue;
            int minValue1 = int.MaxValue;

            int maxValue2 = int.MinValue;
            int minValue2 = int.MaxValue;
            
            for(int i = 0; i < A.Count; i++)
            {
                maxValue1 = Math.Max(maxValue1,A[i] + i);
                minValue1 = Math.Min(minValue1,A[i] + i);

                maxValue2 = Math.Max(maxValue2, A[i] - i);
                maxValue2 = Math.Min(maxValue2, A[i] - i);
            }

            int candidate1 = maxValue1 - minValue1;
            int candidate2 = maxValue2 - minValue2;
            int finAnswer = Math.Max(candidate1, candidate2);
        }

        public static List<List<int>> merinterval(List<List<int>> A, int B, int C)
        {
            List<List<int>> K = new List<List<int>>();
            int endingPoint = int.MinValue;
            int startingPoint = int.MaxValue;
            int _endingPoint = int.MinValue;
            int _startingPoint = int.MaxValue;
            for (int i = 0; i<A.Count; i++)
            {
                int x = A[i][0];
                int y = A[i][1];

                if(isPresent(x,y,B,C))
                {
                    startingPoint = Math.Min(x,B);
                    endingPoint = Math.Max(y, C);
                    //A.RemoveAt(i);                  
                }
                else
                {
                    K.Add(new List<int> { x, y });
                    _startingPoint = B;
                    _endingPoint = C;

                }
                _startingPoint = Math.Min(_startingPoint,startingPoint);
                _endingPoint = Math.Max(_endingPoint,endingPoint);  
            }

            K.Add(new List<int> { _startingPoint, _endingPoint });           
            return K;
        }

        public static bool isPresent(int X, int Y, int B, int C)
        {
            
            if (X <= B && Y >= C)
               return true;

            if (X >= B && Y <= C)
                return true;
    
            if (X <= B && Y >= B)
                return true;

            if (X <= C && Y >= C)
                return true;

            return false;

        }
    }
}
