using System;
using System.IO;
using Ninject;

namespace DIContainer.Solved.Commands
{
	public class HelpCommand : BaseCommand
	{
		private readonly Lazy<ICommand[]> commands;
		private readonly string exeName;
        [MyInject]
        public TextWriter UiWriter { get; set; }

		public HelpCommand(
			Lazy<ICommand[]> commands, 
			[Named("executableName")]string exeName)
		{
			this.commands = commands;
			this.exeName = exeName;
		}

		public override void Execute()
		{
			UiWriter.WriteLine("Available commands: ");
			foreach (var command in commands.Value)
				UiWriter.WriteLine("  > {0} {1}", exeName, command.Name);
		}
	}
}