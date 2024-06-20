using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        public static long NRoot(int n, int m)
        {

            int low = 1;
            int high = m;
            int mid;
            int counter;
            long possibleAns;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                counter = 1;
                possibleAns = 1;
                while (counter <= n)
                {
                    possibleAns = (possibleAns * mid) % 1000000007;
                    if(possibleAns > m) {                        
                        break;
                    }
                    counter++;
                }
                if (possibleAns == m)
                {
                    return mid;
                }
                else if (possibleAns < m)
                {

                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;

            //Your code here
        }

        public static int MinDays(int[] bloomDay, int m, int k)
        {
            int min = int.MaxValue, max = int.MinValue;
            int low, high, minimumDay;
            int ans = -1;
            for(int i = 0; i < bloomDay.Length; i++)
            {
                min = Math.Min(bloomDay[i], min);
                max = Math.Max(bloomDay[i], max);
            }

            low = min;
            high = max;

            if ((m * k) > bloomDay.Length)
                return -1;

            while(low <= high )
            {
                minimumDay = low + (high - low) / 2;

                if(isMinimumDay(bloomDay, minimumDay, m,k))
                {
                    ans = minimumDay;
                    high = minimumDay - 1;
                }
                else
                {
                    low = minimumDay + 1;
                }
            }

            return ans;

        }

        public static bool isMinimumDay(int[]bloom,int day, int requiredBouquet ,int adjacentFlower)
        {
            int possibleBouquet = 0;
            int counter = 0;

            for(int i = 0; i < bloom.Length; i++)
            {
                if (day >= bloom[i])
                {
                    counter++;
                }
                else
                {
                    possibleBouquet += counter / adjacentFlower;
                    counter = 0;
                }                   
            }

            possibleBouquet += counter / adjacentFlower;

            if (possibleBouquet >= requiredBouquet)
                return true;
            else
                return false;
        }
    }
}
