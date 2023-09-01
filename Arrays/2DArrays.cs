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
    }
}
