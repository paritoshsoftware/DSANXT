using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class Contest
    {

        public static List<List<string>> getAnagrams(List<string> A)
        {

            Dictionary<string, List<string>> dictionaryAnagram = new Dictionary<string, List<string>>();

            for (int i = 0; i < A.Count; i++)
            {
                var itemToBeChecked = getSortedString(A[i]);

                if (dictionaryAnagram.ContainsKey(itemToBeChecked))
                {
                    dictionaryAnagram[itemToBeChecked].Add(A[i]);
                }
                else
                {
                    dictionaryAnagram.Add(itemToBeChecked, new List<string>() { A[i] });
                }
            }

            List<List<string>> finalList = new List<List<string>>();

            foreach (var item in dictionaryAnagram)
            {
                List<string> values = new List<string>();
                values.AddRange(item.Value.ToList());
                finalList.Add(values);
            }

            return finalList;
        }


        public static string getSortedString(string anagramItem)
        {
            char[] arr = anagramItem.ToCharArray();
            Array.Sort(arr);
            return string.Join("", arr);
        }

    }
}
