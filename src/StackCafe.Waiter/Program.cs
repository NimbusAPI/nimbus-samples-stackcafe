using System;
using Serilog;
using StackCafe.Common.Logging;

namespace StackCafe.Waiter
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            Log.Logger = DefaultLoggerConfiguration.CreateLogger();
            try
            {
                using (var container = IoC.LetThereBeIoC())
                {
                    Console.ReadKey();
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unhandled exception occurred");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}