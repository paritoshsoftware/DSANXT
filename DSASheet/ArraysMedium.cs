using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
