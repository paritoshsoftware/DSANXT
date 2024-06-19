using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class BinarySearchOnAnswers
    {

        public static long floorSqrt(long x)
        {

            long low = 1;
            long high = x;
            long mid;          
            while(low <= high)
            {
                mid = low + (high - low) / 2;
               
                if (mid * mid == x)
                {
                    
                    return mid;
                }
                else if (mid * mid < x)
                {

                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            
            return high;

            //Your code here
        }
    }
}
