namespace AsyncConsole.Tasks;

public static class TaskDemoV1
{
    public static void Run()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine(nameof(TaskDemoV1));
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();
        
        var cancellationTokenSource = new CancellationTokenSource();

        var argument1 = new Work.Argument(DataSet.NumberDictionary,"A", cancellationTokenSource.Token);
        var task1 = new Task(Work.Run, argument1);
        
        var argument2 = new Work.Argument(DataSet.NumberDictionary,"B", cancellationTokenSource.Token);
        var task2 = new Task(Work.Run, argument2);
        
        var argument3 = new Work.Argument(DataSet.NumberDictionary,"C", cancellationTokenSource.Token);
        var task3 = new Task(Work.Run, argument3);
        
        var argument4 = new Work.Argument(DataSet.NumberDictionary,"D", cancellationTokenSource.Token);
        var task4 = new Task(Work.Run, argument4);

        var taskList = new List<Task>(new[] {task1, task2, task3, task4});
        
        
        Log.WriteLine("Starting work");
        Log.WriteLine();
        
        task1.Start();
        task2.Start();
        task3.Start();
        task4.Start();
        
        Thread.Sleep(Work.Timeout);
        
        // Language-Integrated Query (LINQ)
        var pendingTaskList =
            from t in taskList.AsQueryable()
            where t.Status == TaskStatus.Running
            select t;

        if (!pendingTaskList.Any()) return;
        
        Log.WriteLine();
        Log.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Log.WriteLine("Cancelling work");
        Log.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Log.WriteLine();
        cancellationTokenSource.Cancel();

        Task.WaitAll(task1, task2, task3, task4);
    }
}