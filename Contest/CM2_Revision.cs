using System.Text;

namespace DSA
{
    public class CM2_Revision
    {
        //Three Sum a+b = -c
        //Painter Partition Problem
        //Biased Suvstring
        //Inversion array count
        public static string solve_Frequqency_Based_Strings(string A)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < A.Length; i++)
            {
                if (map.ContainsKey(A[i].ToString()))
                {

                    map[A[i].ToString()]++;
                }else
                {
                    map.Add(A[i].ToString(), 1);
                }
            }            

            foreach (KeyValuePair<string, int> entry in map)
            {
                
                int counter = 1;
                while(counter <= entry.Value)
                {
                    sb.Append(entry.Key);
                    counter++;
                }
               
                // do something with entry.Value or entry.Key
            }

            return sb.ToString();
        }
    }
}