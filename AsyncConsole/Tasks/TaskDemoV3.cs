namespace AsyncConsole.Tasks;

public static class TaskDemoV3
{
    public static void RunWrongWay1()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV3)} (Wrong Way #1)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        var fileWriter = new FileWriter(GetOutputFilePathWithTimestamp("wrong-01"));
        fileWriter.WriteLineAsync("WrongLine1");
        fileWriter.WriteLineAsync("WrongLine2");
        fileWriter.WriteLineAsync("WrongLine3");
        fileWriter.WriteLineAsync("WrongLine4");
        fileWriter.WriteLineAsync("WrongLine5");

        Log.WriteLine("Work finished");
        Log.WriteLine();
    }
    
    public static void RunWrongWay2()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV3)} (Wrong Way #2)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        using (var fileWriter = new FileWriter(GetOutputFilePathWithTimestamp("wrong-02")))
        {
            fileWriter.WriteLineAsync("WrongLine1");
            fileWriter.WriteLineAsync("WrongLine2");
            fileWriter.WriteLineAsync("WrongLine3");
            fileWriter.WriteLineAsync("WrongLine4");
            fileWriter.WriteLineAsync("WrongLine5");
        } 

        Log.WriteLine("Work finished");
        Log.WriteLine();
    }
    
    public static void RunWrongWay3()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV3)} (Wrong Way #3)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        using var fileWriter = new FileWriter(GetOutputFilePathWithTimestamp("wrong-03"));
        fileWriter.WriteLineAsync("WrongLine1");
        fileWriter.WriteLineAsync("WrongLine2");
        fileWriter.WriteLineAsync("WrongLine3");
        fileWriter.WriteLineAsync("WrongLine4");
        fileWriter.WriteLineAsync("WrongLine5");

        Log.WriteLine("Work finished");
        Log.WriteLine();
    }
    
    public static void RunRightWay1()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV3)} (Right Way #1)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        using var fileWriter = new FileWriter(GetOutputFilePathWithTimestamp("right-01"));
        
        var t1 = fileWriter.WriteLineAsync("RightLine1");
        t1.Wait();
        
        var t2 = fileWriter.WriteLineAsync("RightLine2");
        t2.Wait();
        
        var t3 = fileWriter.WriteLineAsync("RightLine3");
        t3.Wait();
        
        var t4 = fileWriter.WriteLineAsync("RightLine4");
        t4.Wait();
        
        var t5 = fileWriter.WriteLineAsync("RightLine5");
        t5.Wait();
        
        Log.WriteLine("Work finished");
        Log.WriteLine();
    }
    
    public static void RunRightWay2()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV3)} (Right Way #2)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        using var fileWriter = new FileWriter(GetOutputFilePathWithTimestamp("right-02"));
        
        fileWriter.WriteLineAsync("RightLine1").Wait();
        fileWriter.WriteLineAsync("RightLine2").Wait();
        fileWriter.WriteLineAsync("RightLine3").Wait();
        fileWriter.WriteLineAsync("RightLine4").Wait();
        fileWriter.WriteLineAsync("RightLine5").Wait();
        
        Log.WriteLine("Work finished");
        Log.WriteLine();
    }
    
    public static async Task RunRightWay3Async()
    {
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine($"{nameof(TaskDemoV3)} (Right Way #3)");
        Log.WriteLine("--------------------------------------------------");
        Log.WriteLine();

        using var fileWriter = new FileWriter(GetOutputFilePathWithTimestamp("right-03"));
        
        await fileWriter.WriteLineAsync("RightLine1");
        await fileWriter.WriteLineAsync("RightLine2");
        await fileWriter.WriteLineAsync("RightLine3");
        await fileWriter.WriteLineAsync("RightLine4");
        await fileWriter.WriteLineAsync("RightLine5");
        
        Log.WriteLine("Work finished");
        Log.WriteLine();
    }

    private static string GetOutputFilePathWithTimestamp(string baseName) =>
        $"Output/{baseName}-{DateTime.Now:HH.mm.ss.fffff}.txt";
}