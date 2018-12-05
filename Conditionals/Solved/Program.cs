using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Conditionals.Solved
{
    public abstract class ConsoleCommand
    {
        protected ConsoleCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public abstract void Execute(string[] args);
    }

    public class PrintTimeCommand : ConsoleCommand
    {
        public PrintTimeCommand() : base("printTime") { }

        public override void Execute(string[] args)
        {
            Console.WriteLine(DateTime.Now);
        }
    }

    public class TimerCommand : ConsoleCommand
    {
        public TimerCommand() : base("timer") { }

        public override void Execute(string[] args)
        {
            var timeout = TimeSpan.FromMilliseconds(int.Parse(args[0]));
            Console.WriteLine("Waiting for " + timeout);
            Thread.Sleep(timeout);
            Console.WriteLine("Done!");
        }
    }
    
    public class HelpCommand : ConsoleCommand
    {
        private readonly Func<string[]> getAvailableCommands;
        public HelpCommand(Func<string[]> getAvailableCommands) : base("help")
        {
            this.getAvailableCommands = getAvailableCommands;
        }

        public override void Execute(string[] args)
        {
            Console.WriteLine("Available commands: ");
            foreach (var command in getAvailableCommands())
                Console.WriteLine(command);
        }
    }

    public class CommandsExecutor
    {
        private readonly List<ConsoleCommand> commands = new List<ConsoleCommand>();

        public void Register(ConsoleCommand command)
        {
            commands.Add(command);
        }

        public string[] GetAvailableCommandNames()
        {
            return commands.Select(c => c.Name).ToArray();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Please specify <command> as the first command line argument");
            var commandName = args[0];
            var cmds = commands.Where(c => c.Name == commandName).ToList();
            if (!cmds.Any())
                Console.WriteLine("Sorry. Unknown command {0}", commandName);
            else
                cmds[0].Execute(args);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var executor = new CommandsExecutor();
            
            executor.Register(new PrintTimeCommand());
            executor.Register(new TimerCommand());
            executor.Register(new HelpCommand(
                () => executor.GetAvailableCommandNames()));

            executor.Execute(args);
        }
    }
}