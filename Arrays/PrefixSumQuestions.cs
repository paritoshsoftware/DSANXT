namespace DSA
{
    public class PrefixSumQuestions
    {
        //Create Prefox sum
        public static void createPrefixSum(List<int> A)
        {

            int noOfElements = A.Count;

            Console.WriteLine("Array Elements");
            foreach (int number in A)
            {
                Console.WriteLine(number);
            }
            int data = A[3];
            // Buiding prefix sum
            List<int> pf = new List<int>();
            
            //Adding initial Oth Element
            pf.Add(A[0]);

            //Processsing Prefix Sum
            for(int i = 1; i < noOfElements; i++)
            {
                int value = pf[i - 1] + A[i];
                pf.Add(value);
            }

            //Prefix Sum Array
            Console.WriteLine("Prefix Sum Array");
            for(int i = 0; i < pf.Count; i++)
            {
                Console.WriteLine(pf[i]);
            }
        }
    }
}