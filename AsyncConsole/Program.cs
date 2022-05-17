using AsyncConsole.Delegates;
using AsyncConsole.Tasks;
using AsyncConsole.Threads;

try
{
    Console.WriteLine("##################################################");
    Console.WriteLine("# BEGIN");
    Console.WriteLine("##################################################");
    Console.WriteLine();

    #region Delegates

    // CalculatorDemoV1.Run();
    // CalculatorDemoV2.Run();
    // CalculatorDemoV3.Run();

    #endregion

    #region Threads
    
    // ThreadDemo.Run();
    
    #endregion

    #region Tasks

    // TaskDemoV1.Run();
    
    // TaskDemoV2.Run();
    
    // TaskDemoV3.RunWrongWay1();
    // TaskDemoV3.RunWrongWay2();
    // TaskDemoV3.RunWrongWay3();
    
    // TaskDemoV3.RunRightWay1();
    // TaskDemoV3.RunRightWay2();
    // TaskDemoV3.RunRightWay3Async();
    // await TaskDemoV3.RunRightWay3Async();

    // await TaskDemoV4.RunAsync();

    #endregion
    
    Console.WriteLine();
    Console.WriteLine("##################################################");
    Console.WriteLine("# END");
    Console.WriteLine("##################################################");
}
catch (Exception exception)
{
    Console.WriteLine(exception.ToString());
}