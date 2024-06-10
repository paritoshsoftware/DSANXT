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
                    lb = Math.Max(nums[mid], lb);
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

        public static int[] SearchRangeFirstAndLast(int[] nums, int target)
        {
            int[] result = new int[2] { -1, -1 };
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

        public static int CountOccurrencesinSortedArray(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            int first = 0, last = 0;
            //first occurance
            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] == target)
                {
                    first = mid;
                    high = mid - 1;
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
            low = 0;
            high = nums.Length - 1;
            //last occurance
            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] == target)
                {
                    last = mid;
                    low = mid + 1;
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

            return (last - first) + 1;
        }


        public static int SearchElementRotatedSortedArray(int[] nums, int target)
        {


            int low = 0;
            int high = nums.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (target == nums[mid])
                    return mid;

                if (nums[low] <= nums[mid])
                {
                    if (nums[low] <= target && target <= nums[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] <= target && target <= nums[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }


        public static bool SearchElementRotatedSortedArray2(int[] nums, int target)
        {


            int low = 0;
            int high = nums.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (target == nums[mid])
                    return true;

                if (nums[low] == nums[mid] && nums[mid] == nums[high])
                {
                    low++;
                    high--;
                }

                if (nums[low] <= nums[mid])
                {
                    if (nums[low] <= target && target <= nums[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] <= target && target <= nums[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return false;
        }
        public static int FindMinAndNowFoTimeArrayRotated(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid;
            int min = int.MaxValue;
            int rotations = 0;
            while(low <= high)
            {
               
                mid = low + (high - low) / 2;

                if (nums[low] <= nums[mid])
                {
                 
                    if (nums[low] < min)
                    {
                        min = nums[low];
                        rotations = low;
                    }
                  
                    low = mid + 1;
                }
                else
                {
                    if (nums[mid] < min)
                    {
                        min = nums[mid];
                        rotations = mid;
                    }

                    high = mid - 1; 
                }
            }

            return min;
        }

        public static int  SingleNonDuplicate(int[] nums)
        {
            int n = nums.Length;
            int mid;

            if(nums.Length == 1)
                return nums[0];
            
            if (nums[n - 1] != nums[n-2])
               return nums[n - 1];
                       

            if (nums[0] != nums[1])
                return nums[0];

            int low = 1;
            int high = n - 2;

            while(low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid-1] != nums[mid] && nums[mid] != nums[mid+1])
                {
                    return nums[mid];
                }
                else if((mid % 2 == 1) && (nums[mid - 1] == nums[mid]) || (mid % 2 == 0) && (nums[mid + 1] == nums[mid]))
                {
                    low = mid + 1;
                }else
                {
                    high = mid - 1;
                }

            }

            return -1;

        }

        /// <summary>
        /// https://leetcode.com/problems/find-peak-element/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] nums)
        {

            int n = nums.Length;
            int low = 1;
            int high = n - 2;
            int mid;

            if (nums.Length == 1 || nums[0] > nums[1]) return 0;

            if (nums[n - 1] >= nums[n - 2]) return n - 1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1])
                    return mid;

                if (nums[mid - 1] < nums[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;

        }

        public static int BasicSearch(int[] nums, int target)
        {
            int result = -1;
            int low = 0;
            int high = nums.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (target == nums[mid])
                {
                    return mid;
                }
                else if (target < nums[mid])
                {
                    low = low + 1;
                }
                else
                {
                    high = high - 1;
                }

            }

            return result;
        }


        public static int BasicLowerSearch(int[] nums, int target)
        {
            int result = -1;
            int low = 0;
            int high = nums.Length - 1;
            int mid = 0;
            int ans = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;
              
                 if ( nums[mid] < target )
                {
                    low = low + 1;
                    ans = low;
                }
                else
                {
                    high = high - 1;
                }

            }

            return ans;
        }

    }
}
