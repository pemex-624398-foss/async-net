namespace AsyncConsole.Tasks;

public static class TaskDemoV2
{
    public static void Run()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine(nameof(TaskDemoV2));
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();
        
        Log.WriteLine("Starting work");
        Log.WriteLine();
        
        var cancellationTokenSource = new CancellationTokenSource();
        
        var task1 = Task.Run(
            () => Work.Run(new Work.Argument(DataSet.NumberDictionary, "A", cancellationTokenSource.Token)), 
            cancellationTokenSource.Token
            );

        var task2 = Task.Run(
            () => Work.Run(new Work.Argument(DataSet.NumberDictionary, "B", cancellationTokenSource.Token)), 
            cancellationTokenSource.Token
            );
        
        var task3 = Task.Run(
            () => Work.Run(new Work.Argument(DataSet.NumberDictionary, "C", cancellationTokenSource.Token)), 
            cancellationTokenSource.Token
            );
        
        var task4 = Task.Run(
            () => Work.Run(new Work.Argument(DataSet.NumberDictionary, "D", cancellationTokenSource.Token)), 
            cancellationTokenSource.Token
            );
        
        cancellationTokenSource.CancelAfter(Work.Timeout);
        Task.WaitAll(task1, task2, task3, task4);
    }
}