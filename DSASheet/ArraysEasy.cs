using System.Globalization;
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
    }
}

public class Solution {
    public void Rotate(int[] nums, int k) {
        
        int size = nums.Length - 1;
        reverseArray(nums, 0, size);
        reverseArray(nums, 0, k - 1);
        reverseArray(nums, k, size);
    }

    public  void reverseArray(int[] nums, int start, int end)
    {
        int temp = 0;
        while(start < end)
        {
            temp = nums[start];
            nums[start++] = nums[end];
            nums[end--] = temp;
        }
    }
}