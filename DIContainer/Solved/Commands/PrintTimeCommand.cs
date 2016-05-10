using System;

namespace DIContainer.Solved.Commands
{
    public class PrintTimeCommand : BaseCommand
    {
	    public override void Execute()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}