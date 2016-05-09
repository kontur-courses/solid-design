using System;
using System.IO;

namespace DIContainer.Commands
{
    public class PrintTimeCommand : BaseCommand
    {
	    public override void Execute()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}