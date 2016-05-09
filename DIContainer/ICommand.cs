using System;
using System.IO;
using System.Linq;
using Ninject;

namespace DIContainer
{
    public abstract class BaseCommand : ICommand
    {
		protected BaseCommand()
        {
            Name = GetType().Name.Split(new [] { ".", "Command" }, StringSplitOptions.RemoveEmptyEntries).Last();
        }

        public string Name { get; private set; }

        public abstract void Execute();
    }

    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}