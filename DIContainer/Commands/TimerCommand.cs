using System;
using System.Threading;

namespace DIContainer.Commands
{
    public class TimerCommand : BaseCommand
    {
        private readonly CommandLineArgs arguments;

        public TimerCommand(CommandLineArgs arguments)
        {
            this.arguments = arguments;
        }

        public override void Execute()
        {
            var timeout = TimeSpan.FromMilliseconds(arguments.GetInt(0));
            Console.WriteLine("Waiting for " + timeout);
            Thread.Sleep(timeout);
            Console.WriteLine("Done!");
        }
    }
}