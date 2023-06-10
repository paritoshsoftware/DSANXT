using System.Linq;
using System.Xml.Linq;

namespace DSA
{
  
   //Definition for binary tree
    
  
   public class Trees1
    {
       public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        public TreeNode buildTree(List<int> A, List<int> B)
        {

            TreeNode root = CBT(A, 0, A.Count - 1, B, 0, B.Count - 1);

            return root;
        }

        public TreeNode insertLevelOrder(int[] arr, int i)
        {
            TreeNode root = null;
            // Base case for recursion
            if (i < arr.Length)
            {
                root = new TreeNode(arr[i]);

                // insert left child
                root.left = insertLevelOrder(arr, 2 * i + 1);

                // insert right child
                root.right = insertLevelOrder(arr, 2 * i + 2);
            }
            return root;
        }

        public TreeNode CBT(List<int> PO, int POS, int POE, List<int> IO, int IOS, int IOE)
        {

            if (POS > POE) return null;

            int x = PO[POS];
            TreeNode root = new TreeNode(x);

            int data = PO[POS];
            int idx = -1 ;
            for (int i = IOS; i <= IOE; i++)
            {
                if (IO[i] == data && IO[i] != -1)
                {
                    idx = i;
                    break;
                }
                
            }

            int l = idx - IOS;


            root.left = CBT(PO,  POS + 1,  POS + l,  IO, IOS,  idx - 1);

            root.right = CBT(PO, POS + l + 1, POE,  IO,  idx + 1,IOE);

            return root;

        }


        public List<List<int>> VerticalOrder(TreeNode A)
        {
            List<List<int>> verticalOrdersList = new List<List<int>>();

            var tuple = new Tuple<int, TreeNode>  (0, A);         

            Queue<Tuple<int, TreeNode>> verticalOrderQueue = new Queue<Tuple<int, TreeNode>>();

            verticalOrderQueue.Enqueue(tuple);

            Dictionary<int, List<int>> orderDictionary = new Dictionary<int, List<int>>();

            int minLevel = Int32.MaxValue;

            int maxLevel = Int32.MinValue;
            
            while(verticalOrderQueue.Count > 0)
            {
                var currentElement = verticalOrderQueue.Dequeue();

                if(orderDictionary.ContainsKey(currentElement.Item1))
                {
                    orderDictionary[currentElement.Item1].Add(currentElement.Item2.val);
                }
                else
                {
                    orderDictionary.Add(currentElement.Item1, new List<int> { currentElement.Item2.val});
                }

                minLevel = Math.Min(minLevel, currentElement.Item1);
                maxLevel = Math.Max(maxLevel, currentElement.Item1);

                if (currentElement.Item2.left != null)
                {
                    var tleft = new Tuple<int, TreeNode>(currentElement.Item1 + (-1), currentElement.Item2.left);
                    verticalOrderQueue.Enqueue(tleft);
                }

                if (currentElement.Item2.right != null)
                {
                    var tright = new Tuple<int, TreeNode>(currentElement.Item1 + (1), currentElement.Item2.right);
                    verticalOrderQueue.Enqueue(tright);
                }
            }
          
            for(int i = minLevel; i <= maxLevel; i++) 
            {
              
                verticalOrdersList.Add(orderDictionary[i].ToList());
               
            }

            return verticalOrdersList;
        }
    }



    public class Trees2
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }
        public TreeNode buildTree(List<int> A, List<int> B)
        {



            return CBT(B, 0, B.Count - 1, A, 0, A.Count - 1);

        

        }

        public TreeNode CBT(List<int> PO, int POS, int POE, List<int> IO, int IOS, int IOE)
        {

            if (POS > POE) return null;

            int x = PO[POE];
            TreeNode root = new TreeNode(x);

            int data = PO[POE];
            int idx = -1;
            for (int i = IOS; i <= IOE; i++)
            {
                if (IO[i] == data && IO[i] != -1)
                {
                    idx = i;
                    break;
                }

            }

            int l = idx - IOS;




            root.left = CBT(PO, POS, POS + l - 1, IO, IOS, idx - 1);
            root.right = CBT(PO, POS + l, POE - 1, IO, idx + 1, IOE);

            return root;

        }
    }
}