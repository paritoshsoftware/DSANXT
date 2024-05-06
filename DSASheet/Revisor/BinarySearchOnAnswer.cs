using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class BinarySearchOnAnswer
    {

        public static int MySqrt(int x)
        {
            int low = 1;
            int high = x;
            long mid;
            long mod = 1000000007;
            while (low <= high)
            {
                mid =  (low + (high - low) / 2);


                if ((long) (mid * mid) <= x)
                {
                    low =(int)mid + 1;
                }
                else
                {
                    high = (int)mid - 1;
                }

            }

            return high;
        }


        public static int NthRoot(int x)
        {
            int low = 1;
            int high = x;
            long mid;
            long mod = 1000000007;
            while (low <= high)
            {
                mid = (low + (high - low) / 2);

                if ((long)(mid * mid) == x)
                {
                    return (int)mid;
                }


                if ((long)(mid * mid) < x)
                {
                    low = (int)mid + 1;
                }
                else
                {
                    high = (int)mid - 1;
                }

            }

            return high;
        }



        public static int MinEatingSpeed(int[] piles, int h)
        {
             int max =  piles.Max();
             int low = 1;
             int high = max;
             int mid;
             double tot;
             while(low <= high)
             {
                mid = low+ (high - low) / 2;
                tot = getTime(piles, mid);
                if (tot > h)
                    low = mid + 1;
                else
                    high = mid - 1;
             }

            return low;

        }

        public static double getTime(int[] piles, int x)
        {
            double totalTime = 0;
            double timeTaken;
               for(int i = 0; i < piles.Length; i++) {
                timeTaken = Convert.ToDouble(piles[i])/x;
                totalTime = (totalTime + Math.Ceiling(timeTaken));
               }

            return totalTime;
        }
    }
}
