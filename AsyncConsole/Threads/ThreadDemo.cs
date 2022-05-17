namespace AsyncConsole.Threads;

public static class ThreadDemo
{
    public static void Run()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine(nameof(ThreadDemo));
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();
        
        var cancellationTokenSource = new CancellationTokenSource();

        var argument1 = new Work.Argument(DataSet.NumberDictionary, "A", cancellationTokenSource.Token);
        var thread1 = new Thread(Work.Run);
        
        var argument2 = new Work.Argument(DataSet.NumberDictionary, "B", cancellationTokenSource.Token);
        var thread2 = new Thread(Work.Run);
        
        var argument3 = new Work.Argument(DataSet.NumberDictionary, "C", cancellationTokenSource.Token);
        var thread3 = new Thread(Work.Run);
        
        var argument4 = new Work.Argument(DataSet.NumberDictionary, "D", cancellationTokenSource.Token);
        var thread4 = new Thread(Work.Run);

        var threadList = new List<Thread>(new[] {thread1, thread2, thread3, thread4});

        Log.WriteLine("Starting work");
        Log.WriteLine();
        
        thread1.Start(argument1);
        thread2.Start(argument2);
        thread3.Start(argument3);
        thread4.Start(argument4);

        Thread.Sleep(Work.Timeout);
        
        // Language-Integrated Query (LINQ)
        var runningThreadList =
            from t in threadList.AsQueryable()
            where t.ThreadState == ThreadState.Running
            select t;

        if (!runningThreadList.Any())
        {
            Log.WriteLine("No more threads running");
            Log.WriteLine();
            return;
        }
        
        Log.WriteLine();
        Log.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Log.WriteLine("Cancelling work");
        Log.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Log.WriteLine();
        cancellationTokenSource.Cancel();
    }
}