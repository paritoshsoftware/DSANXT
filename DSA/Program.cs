using DSA;
//List<int> A = new List<int> { 10, 20, 10, 5, 15 };
//DSA.PrefixSumQuestions.createPrefixSum(A);


//List<int> A = new List<int> {4,2,5,1,3,6,7}; // ointo
//List<int> B = new List<int> {7,6,3,5,4,2,1}; // post

//Trees2 obj = new DSA.Trees2();

//var res =  obj.buildTree(A, B);

Trees1 t2 = new Trees1();
int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
var root = t2.insertLevelOrder(arr, 0);
t2.VerticalOrder(root);