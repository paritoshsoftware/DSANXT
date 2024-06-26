﻿using System.Globalization;

namespace DSA
{
    public class BinarySearchOneDimensionalArrays
    {

        public static int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            int mid; 
        
            while(low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid].Equals(target))
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

        public static int floor(int[] arr, int n, int x)
        {
            int ans = -1, mid;
            int low = 0;
            int high = arr.Length - 1;

            while(low <= high)
            {
                mid = low + (high - low) / 2;
                if (arr[mid] <= x )
                {
                    ans = arr[mid];
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return ans;
        }

        public static int ceil(int[] arr, int n, int x)
        {
            int ans = -1, mid;
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (arr[mid] <= x)
                {
                    low = mid + 1;
                }
                else
                {
                    ans = arr[mid];
                    high = mid - 1;
                }
            }
            return ans;
        }

        public int SearchInsert(int[] nums, int target) {

            int low = 0;
            int high = nums.Length - 1;
            int mid;
            while(low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid].Equals(target))
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
            return low;
        
        }
        //3,4,13,13,13,20,4
     //   0 1  2  3  4  5 6
        public static int[] firstAndLastArray(int[] nums, int target) {
       
            int firstElementIndex = -1, secondElementIndex = -1 ,mid;
            int[] arr = new int[2] { firstElementIndex, secondElementIndex };

            int low = 0;
            int high = nums.Length - 1;


            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] >= target)
                {
                    firstElementIndex = getElement(nums, target, firstElementIndex, mid);
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

            }

            arr[0] = firstElementIndex;

             low = 0;
             high = nums.Length - 1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] <= target)
                {
                    secondElementIndex = getElement(nums, target, secondElementIndex, mid);
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            arr[1] = secondElementIndex;

            return arr;

           
        }

        static int getElement(int[] nums, int target, int firstElementIndex, int mid)
        {
            if (nums[mid].Equals(target))
            {
                firstElementIndex = mid;
            }

            return firstElementIndex;
        }
        //5, 6, 7, 8, 9, 10, 1, 2, 3
        public static int searchElementRoatedArray(int[] nums, int target) {

            int low = 0;
            int high = nums.Length - 1;
            int mid;

            while(low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[mid] == target)
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

        public static int FindMin(int[] nums)
        {

            int low = 0 , mid;
            int high = nums.Length - 1;
            int ans = int.MaxValue;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                if (nums[low] <= nums[mid])
                {
                    ans = Math.Min(ans, nums[low]);
                    low = mid + 1;
                }
                else
                {
                    ans = Math.Min(ans, nums[mid]);
                    high = mid - 1;
                }
                
            }

            return ans;
        }

        public static int FindPeak(int[] nums)
        {
            int n = nums.Length;
            int low = 1;

            int high = n - 2;

            if (n == 1 || nums[0] > nums[1]) return 0;

            if (nums[n - 1] > nums[n - 2]) return n - 1;
            int mid;

            while (low <= high)
            {

                mid = low + (high - low) / 2;

                if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1])
                    return mid;

                if (nums[mid] > nums[mid + 1])
                    high = mid - 1;
                else
                    low = mid + 1;

            }

            return -1;
        }

    }
}
