using System;

namespace DecouplingPatterns.CommandQueue
{
    // The command interface defines the methods that all commands must implement
    public interface ICommand
    {
        Action OnFinished { get; set; }

        void Execute();
    }
}