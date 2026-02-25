Question 1:
Assuming that a subarray means to give an array sequentially, in order.
Algorithm description: The (dynamic) algorithm goes through all the values, so that at each value it checks whether it is worth taking this value as part of the subarray with the maximum sum, or not. The algorithm checks whether it is worth starting the subarray from the current value, or whether it is possible to append the current value to the existing subarray, or perhaps not use this value at all. The algorithm indicates for each value what the highest sum would be if we decide to append it, and what the highest sum would be if we do not take it as part of the array.
The code: (C#)
void Question1(int[] arr)
{
    int start = 0, end = 1, mabyStart = 0, take = arr[0], noTake = 0;
    for (int i = 1; i < arr.Length; i++)
    {
        if (arr[i] > arr[i] + take)
        {
            take = arr[i];
            mabyStart = i;
        }
        else
        {
            take += arr[i];
        }
        if (take > noTake)
        {
            end = i + 1;
            start = mabyStart;
        }
        noTake = Math.Max(take, noTake);
    }
    Console.WriteLine("the max sum is: " + Math.Max(take, noTake));
    //Extracting the solution
    for (int i = start; i < end - 1; i++)
        Console.Write(arr[i] + ", ");
    Console.WriteLine(arr[end - 1]);
}
Runtime complexity: O(n). The algorithm traverses the entire array only twice, and in each iteration performs operations with a cost of O(1). 
Question 2:
Structure description: Hash table T (implemented using the chaining method), for storing data. Numeric variable (int) saveSetAll, for storing the last value updated in the SetAll function. Numeric variable (int) count, for storing the number of times the SetAll function was called, and thereby checking which value to return when calling the Get function.
We will create an object whose fields are val and count, so that every value in the hash table will be of this object type.
Implementation of actions:
Set(key, val): Changing the value in the hash table of key to a new object containing val and count+1. (By using count+1 we can check whether the value was updated before or after calling the SetAll function). – The Set function of the hash table checks whether the key already exists and needs to be changed, or whether it does not yet exist and a new one needs to be added.
The algorithm (in pseudocode):
Set(key, val):
	o <- {val, count+1}
	T.Set(key,o)
Get(key): Check whether there is a value at the key position, if not – return null. If so – check whether the count in the key value is less than or equal to the count of the entire structure, if so – return the value in the saveSetAll variable. If not – return the value in the hash table with the key key.
The algorithm (in pseudocode):
Get(key):
	if not T.HasKey(key):
		return null
	o <- T.Get(key)
	if o.count <= count:
		return saveSetAll
	return o.val
SetAll(val): Changing the value in the saveSetAll variable to val, and changing the count value to count+1.
The algorithm (in pseudocode):
SetAll(val):
	saveSetAll <- val
	count <- count + 1
Runtime complexity:
Set(key, val): O(1) on average – Operations on a hash table take O(1) on average.
Get(key): O(1) on average – Operations on a hash table take O(1) on average.
SetAll(val): O(1) 
Question 3:
Description of the algorithm: The (dynamic) algorithm goes through all the values, and checks for each value whether the value can join the existing list (is it greater than or equal to the largest element in the current list), and if not – for now the only value in its array is itself. The algorithm then checks whether in the array that has existed so far, there is an array that is more worth joining, what is the size of the maximum array that has existed so far, and whether the current value can join.
The code: (C#)
void Question3(LinkedList<int> list)
{
    int[] arr = new int[list.Count];
    for (int i = 0; i < list.Count; i++)
    {
        arr[i] = list.First();
        list.AddLast(list.First());
        list.RemoveFirst();
    }
    int[] tmp = new int[arr.Length];
    int max = 0;
    tmp[0] = 1;
    for (int i = 1; i < tmp.Length; i++)
    {
        if (arr[i] >= arr[i - 1])
            tmp[i] = tmp[i - 1] + 1;
        else
            tmp[i] = 1;
        max = 0;
        for (int j = 0; j < i; j++)
        {
            if (arr[j] <= arr[i])
            {
                max = Math.Max(max, Math.Max(tmp[j] + 1, tmp[i]));
            }
        }
        tmp[i] = max;
    }
    max = 0;
    for (int i = 0; i < tmp.Length; i++)
    {
        max = Math.Max(max, tmp[i]);
    }
    Console.WriteLine("the naximum is "+max+" elements");
    LinkedList<int> ans = new LinkedList<int>();
    //Extracting the solution
    int last = max;
    for (int i = tmp.Length - 1; i >= 0; i--)
    {
        if (tmp[i] == last)
        {
            ans.AddFirst(arr[i]);
            last--;
        }
    }
    for (int i = 0; i < ans.Count(); i++)
    {
        Console.WriteLine(ans.First());
        ans.AddLast(ans.First());
        ans.RemoveFirst();
    }
}

Runtime complexity: O(n^2). The program loops within a loop, so for each value, it goes through all the values that have been there so far. In addition, the program converts the linked list to an array, by going through all the elements in the list, and for each element, inserting it into the array and adding it to the end of the list (to preserve the original list). Total O(2n^2) = O(n^2). (Later in the program there is another O(n) etc. in extracting the solution to the problem, but this is irrelevant)
Question  4:
Assuming that a subarray means to give an array sequentially, in order.
Algorithm Description: The algorithm goes through the entire array, so for each value it checks what options it can create a subarray in. For each subarray option, it sums up all the values in that subarray, and if the sum equals X, it increments the counter by 1.
In the question, I was asked to find how many subarrays, the sum of which is equal to X, and I was not asked to find which arrays. If you are also interested in finding the arrays themselves, and not just how many such arrays there are, add the code:
for(int k=i;k<j;k++)
    Console.Write(arr[k]+", ");
Console.WriteLine(arr[j]);
Inside the condition of the function. (The above code increases the runtime complexity of the function)
The code: (C#)
int Question4(int[] arr, int x)
{
    int count = 0, sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum = 0;
        for (int j = i; j < arr.Length; j++)
        {
            sum += arr[j];
            if (sum == x)
            {
                count++;
            }
        }
    }
    return count;
}
Runtime complexity: O(n^2). The program has a loop within a loop. For each value (n values), the program checks which subarrays there are that start with the above value (n values, minus the number of values already checked so far). 
Question 5:
Explanation of the algorithm: If there were no eggs that contained both a game and a toy, we would say that the formula is the maximum of the quantities, (the games or toys) + 1. So when the maximum + 1 is taken out, it is certain that eggs of both types will come out, because there is not enough quantity that is only one type of this color. Since there are duplicates, we added more parameters to the formula. If the amount of values of both types together is higher than the total amount of eggs, it is certain that there are duplicates, and the same applies when fewer eggs than the maximum amount are opened, it is certain that there will be eggs of both types.
In fact, the formula is the maximum of the two types, plus 1, minus the amount of duplicates there are (S + T – N)
The code: (C#)
int Question5(int n, int s, int t)
{
    return Math.Max(s, t) + 1 - (s + t - n);
}

