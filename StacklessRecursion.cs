using System.Collections;


void StacklessRecursion(IEnumerator<IEnumerator> f)
{
    var stack = new List<IEnumerator<IEnumerator>> { f };

    while(stack.Count > 0)
    {
        var stackTop = stack[^1];
        if (stackTop.MoveNext())
            stack.Add((IEnumerator<IEnumerator>)stackTop.Current);
        else
            stack.RemoveAt(stack.Count - 1);
    }
}




double Factorial(long i)
{
    double ret = default;
    StacklessRecursion(impl(i));
    return ret;

    IEnumerator<IEnumerator> impl(long i)
    {
        if (i <= 1)
            ret = 1;
        else
        {
            yield return impl(i - 1);
            ret = i * ret;
        }
    }
}

long Fibonacci(long i)
{
    long ret = default;
    StacklessRecursion(impl(i));
    return ret;

    IEnumerator<IEnumerator> impl(long i)
    {
        if (i <= 1)
            ret = i;
        else
        {
            yield return impl(i - 1);
            var a = ret;
            yield return impl(i - 2);
            ret = a + ret;
        }
    }
}



void StacklessRecursion_UsageExample()
{
    Console.WriteLine("Factorial:");
    for (int t = 0; t < 100; ++t)
        Console.WriteLine(Factorial(t));

    Console.WriteLine(Factorial(100000));
    Console.WriteLine("Completed successfully without a crash!\n");

    Console.WriteLine("Fibonacci:");
    for (int t = 0; t < 25; ++t)
        Console.WriteLine(Fibonacci(t));
}


StacklessRecursion_UsageExample();
