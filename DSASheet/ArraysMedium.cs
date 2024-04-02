using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSA
{
    public class ArraysMedium
    {

        public static int [] SumProblem2()
        {
            int target = 6;
            int[] nums = new int[3] { 3, 2, 4 };
            Dictionary<int,int> dic = new Dictionary<int,int>();
            Array.Sort(nums);

            for(int k = 0; k < nums.Length; k++)
            {
                dic.Add(nums[k], k);
            }

            int[] result = new int[2];
            int i = 0;
            int j = nums.Length - 1;

            int sum; 
            while (i < j)
            {
                sum = nums[i] + nums[j];

                if(sum == target)
                {
                    result[0] = i;
                    result[1] = j;
                    break; ;
                }

                else if(sum > target) {
                    j--;
                }
                else
                {
                    i++;
                }

            }
           return result;

        }

        /// <summary>
        /* Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
        We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
        You must solve this problem without using the library's sort function.*/
        /// </summary>
        ///https://leetcode.com/problems/sort-colors/description/
        /// <param name="nums"></param>
        public static void SortColors(int[] nums)
        {
            int mid = 0;
            int low = 0;
            int high = nums.Length - 1;

            while(mid <= low)
            {
                if (nums[mid] == 0)
                {
                    swap(nums, mid, low);
                    low++;
                    mid++;
                }
                else if (nums[mid]==1)
                {
                    mid++;
                }
                else
                {
                     swap(nums,mid, high);
                    high--;
                }
            }
        }

        private static void swap(int[] nums, int mid, int pointer)
        {
            int temp = nums[mid];
            nums[mid] = nums[pointer];
            nums[pointer] = temp;
        }

        /// <summary>
        // Given an array nums of size n, return the majority element.
        // The majority element is the element that appears more than ⌊n / 2⌋ times.You may assume that the majority element always exists in the array.
        /// </summary>
        /// <param name="nums"></param>
        /// https://leetcode.com/problems/majority-element/submissions/1206877439/
        /// https://takeuforward.org/data-structure/sort-an-array-of-0s-1s-and-2s/       
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int majorityElement = nums[0];
            int possibeFreq = 0;
            int majorityFreq = nums.Length / 2;
            int freq = 0;
            int ans = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]==majorityElement)
                {
                    possibeFreq++;
                }
                else
                {
                    possibeFreq--;
                }
                if (possibeFreq <= 0)
                {
                    majorityElement = nums[i];
                    possibeFreq++;
                }
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == majorityElement)
                {
                    freq++;
                }
            }
           
            if(freq > majorityFreq)
            {
                ans =  majorityElement;
            }
            return ans;

        }

        /// <summary>
        /// Given an integer array nums, find the subarray with the largest sum, and return its sum.
        /// </summary>
        /// <param name="nums"></param>
        /// https://leetcode.com/problems/maximum-subarray/description/
        /// <returns></returns>
        public static int MaxSubArray(int[] nums)
        {
            int max = int.MinValue;
            int sum = 0;

            for(int i = 0; i <= nums.Length - 1; i++)
            {
                sum += nums[i];


                max = Math.Max(sum, max);

                if (sum < 0)
                   sum = 0;           

            } 

            return max;
        }

        /// <summary>
        ///You are given a 0-indexed integer array nums of even length consisting of an equal number of positive and negative integers.
        ///You should return the array of nums such that the the array follows the given conditions:
        ///Every consecutive pair of integers have opposite signs.
        ///For all integers with the same sign, the order in which they were present in nums is preserved.
        ///The rearranged array begins with a positive integer.
        ///Return the modified array after rearranging the elements to satisfy the aforementioned conditions.
        ///https://leetcode.com/problems/rearrange-array-elements-by-sign/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] RearrangeArray(int[] nums)
        {
            int[]  ans = new int[nums.Length];
            int pos = 0, neg = 1;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i]<0)
                {

                    ans[neg] = nums[i];
                    neg=+2;
                }
                else
                {
                    ans[pos] = nums[i];
                    pos=+2;
                }
            }

            return ans;
        }


        public static int LongestConsecutive(int[] nums)
        {
            HashSet<int> ans = new HashSet<int>();

            for(int i = 0; i < nums.Length; i++)
            {
                ans.Add(nums[i]);
            }

            int counter = 0;
            int longestCount = int.MinValue;           
            for(int i = 0; i < nums.Length; i++) {

                if (!ans.Contains(nums[i] - 1))
                {
                    int possibleStartingPoint = nums[i];
                    while (true)
                    {
                        if (ans.Contains(possibleStartingPoint + 1))
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 0;                           
                        }

                        longestCount = Math.Max(longestCount, counter);

                        if (counter == 0) break;
                    }
                }
            }

            return longestCount;
        }

    }
}
