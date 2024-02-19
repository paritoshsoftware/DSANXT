using System;
using System.Security.Cryptography;

namespace DSA
{
    public static class PrefixSumQuestions
    {
        //Create Prefox sum

        public static void setMatrixZero()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[4];
            matrix[1] = new int[4];
            matrix[2] = new int[4];
            List<int> list = new List<int>() { 0, 1, 2, 0, 3, 4, 0, 2, 1, 3, 1, 5 };
            int counter = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = list[counter];
                    counter++;
                }
            }

            Console.WriteLine("Original - Matrix");
            
            PrintMatrix(matrix);

            Console.WriteLine("**********************Solution****************************");

            bool isFirstRow = false, isFirstColumn = false;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0) isFirstRow = true;
                        if (j == 0) isFirstColumn = true;
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            Console.WriteLine("First Row and Column Changes - Matrix");

            PrintMatrix(matrix);

            for(int i = 1; i < matrix.Length; i++)
            {
                for(int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (isFirstRow)
            {
                for(int j = 0; j < matrix[0].Length; j++)
                    matrix[0][j] = 0;
            }

            if (isFirstColumn)
            {
                for (int i = 0; i < matrix.Length; i++)
                    matrix[i][0] = 0;
            }

            Console.WriteLine("Final Solution");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j].ToString().PadLeft(4));
                    Console.Write(" | ");
                }

                Console.WriteLine();
            }
        }

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