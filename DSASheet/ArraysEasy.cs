﻿using System.Globalization;
using System.Linq.Expressions;

namespace DSA
{
    public class ArraysEasy
    {
        public static void largestNumberInArray()
        {
            List<int> list = new List<int>() { 2, 5, 1, 3, 99 };

            int possibleMaximumValue = int.MinValue;

            for (int i = 0; i < list.Count; i++)
            {
                possibleMaximumValue = Math.Max(possibleMaximumValue, list[i]);
            }

            Console.WriteLine($"Maximum Value {possibleMaximumValue}");

            Console.WriteLine($"Time Complexity O(n)");
            Console.WriteLine($"Space Complexity O(1)");
        }

        public static void secondLargestInArray()
        {
            List<int> list = new List<int>() { 2, 5, 1, 230, 99,34,768,23,65,89 };

            int firstMaxNumber = int.MinValue;

            for(int i =0; i < list.Count; i++) {
                firstMaxNumber = Math.Max(firstMaxNumber, list[i]);
            }

            Console.WriteLine($"Maximum Value {firstMaxNumber}");

            int secondMaxNumber = int.MinValue;
            for(int i = 0; i<list.Count; i++) {
                if (list[i] > secondMaxNumber && list[i] < firstMaxNumber) {
                    secondMaxNumber = list[i];
                }
            }

            Console.WriteLine($"Second Maximum Value {secondMaxNumber}");

            Console.WriteLine($"Time Complexity O(n+n)");
            Console.WriteLine($"Space Complexity O(1)");
        }

        public static void secondLargestInArraySingleTraversal()
        {
            List<int> numbers = new List<int>() { 2, 5, 1, 768, 99, 34, 567, 23, 65, 89 };

            int largeNumber = int.MinValue;
            int secondLargeNumber = int.MinValue;

            for(int i = 0; i< numbers.Count; i++) {
                if (numbers[i] > largeNumber)
                {
                    secondLargeNumber = largeNumber;
                    largeNumber = numbers[i];                   
                }
                else if (numbers[i] > secondLargeNumber && numbers[i] < largeNumber)
                {
                    secondLargeNumber = numbers[i];
                }
            }
            Console.WriteLine($"Maximum Value {largeNumber}");
            Console.WriteLine($"Second Maximum Value {secondLargeNumber}");

            Console.WriteLine($"Time Complexity O(n+n)");
            Console.WriteLine($"Space Complexity O(1)");
        }

        public static bool checkIfArrayisSorted()
        {
            int[] nums = new int[5] {3,2,3,8,9};           
          
            for(int i = 0; i < nums.Length - 1; i++ )
            {
                if (nums[i] > nums[i+1]) return false;
            }
         
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>int</returns>
        public static int removeDuplicatesWithExtraSpace(int[] nums)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>();

            for(int i = 0; i < nums.Length; i++ ) {

                uniqueNumbers.Add(nums[i]);
            }

            int size  = uniqueNumbers.Count;

            int k = 0;
            foreach(int num in uniqueNumbers)
            {
                nums[k++] = num;             
            }

            return size;
        }

        /// <summary>
        ///  https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/
        /// </summary>
        /// <param name="nums">1, 1, 2, 2, 2, 3, 3</param>
        /// <returns></returns>
        public static int removeDuplicatesWithoutExtraSpace(int[] nums)
        {
            int i = 0;

            for(int j = 1;  j < nums.Length; j++ )
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i]= nums[j];
                }
            }
            
            return i+1;
        }


        /// <summary>
        /// https://leetcode.com/problems/rotate-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int rotateArray1(int[] nums, int k)
        {
            int firstElementIndex = 0;
            int temp = 0;
           
            while(k > 0)
            {

                temp = nums[nums.Length - 1];
                for(int i = nums.Length - 2 ; i >=0; i-- )
                {
                    nums[i+1] = nums[i];
                }
                nums[0] = temp;
                k--;
            }

            return firstElementIndex;

        }

        /// <summary>
        /// https://leetcode.com/problems/rotate-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool rotateArray2(int[] nums, int k)
        {
            k = k % nums.Length;
            reverseArray(nums, 0, nums.Length-1) ;
            reverseArray(nums, 0, k - 1);
            reverseArray(nums, k, nums.Length - 1);

            foreach(int i in nums)
                Console.Write(i) ;

            return true ;
        }

        private static void reverseArray(int[] nums, int i, int j)
        {
            int temp;
            while (i < j)
            {
                temp = nums[i];
                nums[i++] = nums[j];
                nums[j--] = temp;
            }
        }


        /// <summary>
        /// https://leetcode.com/problems/single-number/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int SingleNumber(int[] nums)
        {
            int ans = 0;

            for (int i = 0; i < nums.Length; i++)
                ans = ans ^ nums[i];

            return ans;
        }
        /// <summary>
        /// https://leetcode.com/problems/move-zeroes/description/
        /// </summary>
        /// <param name="nums"></param>
        public static bool moveZeroToEnd(int[] nums)
        {
            int i, j = -1;

            for(i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    j = i;
                    break;
                }
            }
            int temp ;
            for(i = j+1; i< nums.Length; i++)
            {
                if (nums[i]!=0)
                {
                    temp = nums[i];                  
                    nums[i] = nums[j];
                    nums[j] = temp;
                    j++;
                }
            }

            return true;

        }

        /// <summary>
        /// Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
        /// </summary>
        /// <param name="nums">
        /// Input: nums = [3,0,1]
        /// Output: 2
        /// Explanation: n = 3 since there are 3 numbers, so all numbers are in the range[0, 3]. 2 is the missing number in the range since it does not appear in nums.
        /// </param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int sum = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
            }

            int sumOfNumbers = (n*(n + 1)/2);

            int missingNumber = sumOfNumbers - sum;

            return missingNumber;

        }
        /// <summary>
        /// https://leetcode.com/problems/missing-number/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public static int MissingNumber2(int[] nums)
        {
            int n = nums.Length;
            
            int xor1 = nums[0] , xor2 = 1 ;

            for(int i = 1; i < n; i++)
            {
                xor1 = xor1 ^ nums[i];
            }
            for (int i = 2; i <= n; i++)
            {
                xor2 = xor2 ^ i;
            }
           

            int missingNumber = xor1 ^ xor2;

            return missingNumber;

        }


        /// <summary>
        /// https://leetcode.com/problems/max-consecutive-ones/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int counter = 0;

            int maxCountValue = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    counter++;                    
                }
                else
                { 
                    counter = 0;
                }

                maxCountValue = Math.Max(maxCountValue, counter);

            }

            return maxCountValue;
        }
    }
}

