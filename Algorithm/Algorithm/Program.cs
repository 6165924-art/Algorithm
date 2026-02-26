using Algorithm;

//Explanations to all the questions, in the answers.docx file

//1
void Question1(int[] arr)
{
    int start = 0, end = 1, mabyStart = 0, take = arr[0], noTake = arr[0];
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

//2 - in the Question2 class

//3
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
    Console.WriteLine("the naximum is " + max + " elements");
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
        Console.Write(ans.First()+", ");
        ans.AddLast(ans.First());
        ans.RemoveFirst();
    }
    Console.WriteLine();
}
//4
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
//5
int Question5(int n, int s, int t)
{
    return Math.Max(s, t) + 1 - (s + t - n);
}

//Examples of running:
Question1([1, 2, -1, 3, 6, -5, 0, -7, 2]);
Question1([1, 2, -1, 3, 6, -5, 0, -7, 2, 10]);
Question1([-10, -2, -1, -3, -6, -5, -5, -7, -2, -10]);

Question2 q2 = new Question2();
q2.Set(1, 8);
q2.Set(5, 3);
q2.Set(6, 2);
q2.SetAll(1);
q2.Set(6, 7);
Console.WriteLine(q2.Get(1));
Console.WriteLine(q2.Get(5));
Console.WriteLine(q2.Get(6));

LinkedList<int> l = new LinkedList<int>();
l.AddFirst(6);
l.AddFirst(10);
l.AddFirst(9);
l.AddFirst(2);
l.AddFirst(5);
l.AddFirst(3);
l.AddFirst(1);
Question3(l);

Console.WriteLine(Question4([1, 3, 20, -9, -4, 3, -3], 10));
Console.WriteLine(Question4([1, 3, 20, -9, -4, 3, -3, 0, 10], 10));

Console.WriteLine(Question5(20, 16, 15));
Console.WriteLine(Question5(15, 15, 6));