using System.Linq;

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