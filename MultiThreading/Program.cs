using System.Diagnostics;
using System.Linq.Expressions;

var timer = new Stopwatch();
timer.Start();
Console.WriteLine("Starting operation");

ShortRunningOperation();
MediumRunningOperation();
LongRunningOperation();

timer.Stop();
Console.WriteLine($"Total running time: {timer.ElapsedMilliseconds / 1000} seconds");



void LongRunningOperation()
{
    Thread.Sleep(10000);
    Console.WriteLine("Long running operation complete");
}

void ShortRunningOperation()
{
    Thread.Sleep(2000);
    Console.WriteLine("Short running operation complete");
}

void MediumRunningOperation()
{
    Thread.Sleep(5000);
    Console.WriteLine("Medium running operation complete");
}
