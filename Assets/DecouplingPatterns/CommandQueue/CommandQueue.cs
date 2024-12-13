using System.Collections.Generic;

namespace DecouplingPatterns.CommandQueue
{
    //该类管理一个命令队列，确保命令按顺序执行，并且一次只有一个命令正在运行
    public class CommandQueue
    {
        private readonly Queue<ICommand> _queue;
        public bool _isPending; // it's true when a command is running

        public CommandQueue()
        {
            _queue = new Queue<ICommand>();
            _isPending = false;
        }

        public void Enqueue(ICommand cmd)
        {
            _queue.Enqueue(cmd);

            if (!_isPending) // if no command is running, start to execute commands
                DoNext();
        }

        public void DoNext()
        {
            if (_queue.Count == 0)
                return;

            ICommand cmd = _queue.Dequeue();
            // setting _isPending to true means this command is running
            _isPending = true;
            // listen to the OnFinished event
            cmd.OnFinished += OnCmdFinished;
            cmd.Execute();
        }

        private void OnCmdFinished()
        {
            // current command is finished
            _isPending = false;
            // run the next command
            DoNext();
        }

        public void Clear()
        {
            _queue.Clear();
            _isPending = false;
        }
    }
}