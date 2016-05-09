using System;
using System.Linq;

namespace DIContainer
{
    public class CommandLineArgs
    {
        private readonly string[] args;

        public CommandLineArgs(params string[] args)
        {
            this.args = args;
        }

        public string Command
        {
            get
            {
                if (args.Length == 0) return null;
                return args[0];
            }
        }

        public int ArgsCount { get { return args.Length - 1; } }

        public int GetInt(int index, int defaultValue = 0)
        {
            return index < ArgsCount ? int.Parse(args[index + 1]) : defaultValue;
        }
    }
}