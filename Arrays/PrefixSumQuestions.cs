using System;

namespace DSA
{
    public class PrefixSumQuestions
    {
        //Create Prefox sum
        public static void createPrefixSum(List<int> A)
        {

            int noOfElements = A.Count;

            Console.WriteLine("Array Elements");
            foreach (int number in A)
            {
                Console.WriteLine(number);
            }
            int data = A[3];
            // Buiding prefix sum
            List<int> pf = new List<int>();

            //Adding initial Oth Element
            pf.Add(A[0]);

            //Processsing Prefix Sum
            for (int i = 1; i < noOfElements; i++)
            {
                int value = pf[i - 1] + A[i];
                pf.Add(value);
            }

            //Prefix Sum Array
            Console.WriteLine("Prefix Sum Array");
            for (int i = 0; i < pf.Count; i++)
            {
                Console.WriteLine(pf[i]);
            }
        }
      //  [4,2,5,7,4,2,3,6,8,2,3]
        public static void rainwatertrap(List<int> A)
        {
            int finalanswer = 0;
            List<int> leftMax = new List<int>(new int[A.Count]);

            List<int> rightMax = new List<int>(new int[A.Count]);          
          

            for(int i = 1; i < A.Count; i++)
            {
                leftMax[i] = Math.Max(leftMax[i-1], A[i-1]);
            }


            for (int i = A.Count-2; i >=0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], A[i + 1]);
            }


            for(int i = 1; i <= A.Count-2; i++)
            {
                int val = Math.Min(leftMax[i], rightMax[i]) - A[i];

                if (val > 0)
                    finalanswer += val;
            }

            Console.WriteLine(finalanswer);
        }

        public static void continousumquery(int A, List<List<int>> B)
        {
            List<int> answer = new List<int>(new int[A]);
            List<int> psum = new List<int>(new int[A]);
            for (int i = 0; i < B.Count; i++)
            {
                int s = (B[i][0]) - 1;
                int e = (B[i][1]) - 1;
                int val = B[i][2];

                answer[s] += val;
                if(e < A-1 )
                answer[e+1] -= val;
            }


            for(int i = 0; i < answer.Count; i++)
            {
                if (i == 0)
                    psum[i] = answer[i];
                else
                   psum[i] = psum[i - 1] + answer[i];
            }

            Console.WriteLine(psum);
        }
    }
}