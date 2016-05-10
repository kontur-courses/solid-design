using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DIContainer.Solved.Commands;
using Ninject;

namespace DIContainer.Solved
{
    public class Program
	{
		private readonly CommandLineArgs arguments;
		private readonly ICommand[] commands;
		private readonly TextWriter uiWriter;

		public Program(CommandLineArgs arguments, TextWriter uiWriter, params ICommand[] commands)
		{
			this.arguments = arguments;
			this.commands = commands;
			this.uiWriter = uiWriter;
		}

		public static void Main(string[] args)
		{
			// Пример настроек контейнера
			var container = new StandardKernel(
				new NinjectSettings
				{
					InjectNonPublic = true,
					InjectAttribute = typeof(MyInjectAttribute),
				});

			// Константы:
			container.Bind<CommandLineArgs>().ToSelf().WithConstructorArgument(args);
			var exeName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
			container.Bind<string>()
				.ToConstant(exeName).Named("executableName"); // пример именованного биндинга (см. HelpCommand)
			container.Bind<TextWriter>()
				.ToConstant(Console.Out)
				.When(r => r.Target.Name.Equals("uiWriter", StringComparison.OrdinalIgnoreCase));

			// Вариант 1. Ручная конфигурация
			container.Bind<ICommand>().To<PrintTimeCommand>();
			container.Bind<ICommand>().To<TimerCommand>();
			container.Bind<ICommand>().To<HelpCommand>();

			// Вариант 2. Conventtion over configuration
			//			container.Bind(c => 
			//				c.FromThisAssembly()
			//				.SelectAllClasses().BindAllInterfaces()
			//				.Configure(dc => dc.InSingletonScope()));

			container.Get<Program>().Run();
		}

		public void Run()
		{
			if (arguments.Command == null)
			{
				uiWriter.WriteLine("Please specify <command> as the first command line argument");
				return;
			}
			var command = commands.FirstOrDefault(c => c.Name.Equals(arguments.Command, StringComparison.OrdinalIgnoreCase));
			if (command == null)
				uiWriter.WriteLine("Sorry. Unknown command {0}", arguments.Command);
			else
				command.Execute();
		}
	}
}
