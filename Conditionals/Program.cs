using System;
using System.Threading;

namespace Conditionals
{
	public class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length == 0)
				Console.WriteLine("Please specify <command> as the first command line argument");
			var command = args[0];
            if (command == "help")
                ExecuteHelp();
            else if (command == "timer")
				ExecuteTimer(int.Parse(args[1]));
			else if (command == "printtime")
				ExecutePrintTime();
			else ShowUnknownCommandError(args[0]);
		}

        private static void ExecuteHelp()
        {
            Console.WriteLine("Available commands: ");
            foreach (var command in new[] { "timer", "printtime", "help" })
                Console.WriteLine(command);
        }

		private static void ExecutePrintTime()
		{
			Console.WriteLine(DateTime.Now);
		}

		private static void ExecuteTimer(int time)
		{
			var timeout = TimeSpan.FromMilliseconds(time);
			Console.WriteLine("Waiting for " + timeout);
			Thread.Sleep(timeout);
			Console.WriteLine("Done!");
		}

        private static void ShowUnknownCommandError(string command)
        {
            Console.WriteLine("Sorry. Unknown command {0}", command);
        }
    }
}