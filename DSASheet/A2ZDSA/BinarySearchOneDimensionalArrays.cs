using System.Globalization;

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
    }
}
