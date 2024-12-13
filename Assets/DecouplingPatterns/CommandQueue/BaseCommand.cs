using System;

namespace DecouplingPatterns.CommandQueue
{
    public class BaseCommand : ICommand
    {
        public Action OnFinished { get; set; }
        protected readonly GameController _owner;

        protected BaseCommand(GameController owner)
        {
            _owner = owner;
        }

        public virtual void Execute() { }

        protected virtual void OnClose() { }
    }
}