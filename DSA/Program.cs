using DSA;
//List<int> A = new List<int> { 10, 20, 10, 5, 15 };
//DSA.PrefixSumQuestions.createPrefixSum(A);


List<int> A = new List<int> {4,2,5,1,3,6,7}; // ointo
List<int> B = new List<int> {7,6,3,5,4,2,1}; // post

Trees2 obj = new DSA.Trees2();

var res =  obj.buildTree(A, B);
