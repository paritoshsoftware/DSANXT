using DSA;
//List<int> A = new List<int> { 10, 20, 10, 5, 15 };
//DSA.PrefixSumQuestions.createPrefixSum(A);


//List<int> A = new List<int> {4,2,5,1,3,6,7}; // ointo
//List<int> B = new List<int> {7,6,3,5,4,2,1}; // post

//Trees2 obj = new DSA.Trees2();

//var res =  obj.buildTree(A, B);

//Trees1 t2 = new Trees1();
//int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
//var root = t2.insertLevelOrder(arr, 0);
//t2.VerticalOrder(root);

//Greedy p = new Greedy();
//List<int> A = new List<int> { 1, 5, 8, 7, 13, 12 };
//List<int> B = new List<int> { 2, 10, 10, 11, 19, 20 };
//p.finishMaximumJobs(A, B);


List<int> A = new List<int> { 22, 52, 22, 67, 73, 54, 83, 8, 95, 51, 96, 40, 97, 33, 46, 24, 21, 90, 66, 47, 26, 24, 21, 50, 8, 50, 86, 41, 9, 57, 51, 35, 89, 11, 68, 2, 75, 76, 60, 2, 1, 52, 58, 26, 97, 58 };
List<int> B = new List<int> { 53, 78, 14, 97, 84, 55, 11, 5, 31, 9, 80, 82, 20, 3, 7, 78, 59, 95, 80, 66, 26, 48, 6, 32, 57, 66, 48, 44, 96, 61, 28, 19, 32, 10, 80, 42, 26, 21, 88, 9, 36, 74, 41, 81, 42, 4};
int C = 37;
DP p = new DP();
Console.WriteLine(p.fractionalknapsack(A, B, C));
