using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
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

            if ((long)(m * k) > bloomDay.Length)
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

            return (possibleBouquet >= requiredBouquet);
            
        }

        public static int ShipWithinDays(int[] weights, int days)
        {

            int maximumWeight = 0;
            int minimumShipWeight = -1;

            for (int i=0; i < weights.Length; i++)
            {
                maximumWeight += weights[i];
            }

            int low = 1;
            int high = maximumWeight;
            int minimumPossibleWeight;
            int result;

            while(low <= high)
            {
                minimumPossibleWeight = low + (high - low) / 2;

                result = checkMinimumDays(weights, days, minimumPossibleWeight);

                if (result == 1 || result == 3 )
                {
                    minimumShipWeight = minimumPossibleWeight;
                    high = minimumPossibleWeight - 1;
                }
                else 
                {
                    low = minimumPossibleWeight + 1;
                }                      


            }

            return minimumShipWeight;

        }

        public static int checkMinimumDays(int[] weights, int days , int possibleWeight) {

            int daysCounter = 1;
            int commulativeWeight = 0;

            for(int i = 0; i <weights.Length;i++)
            {
                commulativeWeight += weights[i];

                if (weights[i] > possibleWeight || commulativeWeight > possibleWeight)
                {
                    daysCounter++;
                    commulativeWeight = 0;
                    i--;
                    if (daysCounter > days) break;
                    continue;
                }
            }

            if(daysCounter== days)
            {
                return 1;
            }
            else if(daysCounter > days) {
                return 2;
            }
            else
            {
                return 3;
            }
        
        }


        public static int FindKthPositive(int[] arr, int k)
        {

            int low = 0;
            int high = arr.Length - 1;
            int mid ;
            int missing ;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                missing = arr[mid] - (mid + 1);
                if (missing < k)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return low + k;

        }

        public static int aggressive_cows(int[] arr, int k)
        {
           
            Array.Sort(arr);
            int low = 1;
            int high = arr[arr.Length-1] - arr[0];
            int mid;
            while(low <= high)
            {
                mid = low + (high - low) / 2;
               if(canWePlace(arr, mid, k))
                {
                    low = mid + 1; 
                }
               else
                {
                    high = mid - 1;
                }
            }

            return high;

        }

        public static bool canWePlace(int[] cows, int dist, int desiredCows)
        {
            int cntCows = 1;
            int last = cows[0];
            for( int i = 1; i < cows.Length; i++)
            {
                if (cows[i] - last >= dist )
                {
                    cntCows++;
                    last = cows[i];
                }
                   

                if (cntCows >= desiredCows)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// BookAllocation and Split Array nad PainterPartitionProblem also Checa Ship M Pacages
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int findPages(int [] arr, int n, int m)
        {
            if (m > n)
                return -1;
            int low = arr.Max();
            int high = arr.Sum();
            int mid;
            int students;
            while(low <= high)
            {
                mid = low + (high - low) / 2;
                students = canWeFindStudents(arr, mid);
                if (students > m)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return low;
        }
        
        public static int canWeFindStudents(int[] arr, int possiblePages)
        {
            int noOfStudent = 1;
            long comulativePages = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (comulativePages + arr[i] <= possiblePages)
                {
                    comulativePages += arr[i];
                }
                else
                {
                    noOfStudent++;                    
                    comulativePages = arr[i];
                }
            }


            return noOfStudent;
        }
    }
}
