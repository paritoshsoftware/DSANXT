using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace DSA
{
    public class BinarySearch
    {
        /// <summary> 
        //Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums.If target exists, then return its index.Otherwise, return -1.
//You must write an algorithm with O(log n) runtime complexity.
//Example 1:
//Input: nums = [-1, 0, 3, 5, 9, 12], target = 9
//Output: 4
//Explanation: 9 exists in nums and its index is 4
//Example 2:
//Input: nums = [-1, 0, 3, 5, 9, 12], target = 2
//Output: -1
//Explanation: 2 does not exist in nums so return -1
//Constraints:
//
//1 <= nums.length <= 104
//-104 < nums[i], target< 104
//All the integers in nums are unique.
//nums is sorted in ascending order.
        /// </summary>
        /// <param name="nums">arrays of integer</param>
        /// <param name="target">answer</param>
        /// <returns></returns>
        public static int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/search-insert-position/description/
        /// https://takeuforward.org/arrays/search-insert-position/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return low;
        }


        public static int LowerBound_Floor(int[] nums, int x)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            int lb = int.MinValue;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (nums[mid] <= x)
                {
                    lb = Math.Max(nums[mid],lb);
                    low = mid + 1;                    
                }
                    
                else
                    high = mid - 1;
            }

            return lb;
        }

        public static int UppperBound_Ceil(int[] nums, int x)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            int ub = int.MaxValue;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (nums[mid] >= x)
                {
                    ub = Math.Min(ub, nums[mid]);   
                    high = mid - 1;
                }
                else
                    low = mid + 1;
            }

            return ub;
        }

        public static int[]  SearchRangeFirstAndLast(int[] nums, int target)
        {
            int[] result = new int[2] {-1,-1};
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            int x = target;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (nums[mid] == x)
                {
                    result[0] = mid;
                    high = mid - 1;
                }
                else if (nums[mid] < x)
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            low = 0;
            high = nums.Length - 1;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (nums[mid] == x)
                {
                    result[1] = mid;
                    low = mid + 1;
                }
                else if (nums[mid] < x)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

                    
            return result;

        }
    }   
}
