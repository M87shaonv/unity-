using UnityEngine;

namespace DecouplingPatterns.CommandQueue
{
    public class GameController : MonoBehaviour
    {
        public Popup firstPopUp, secondPopup, thirdPopup;

        private CommandQueue _commandQueue;

        private void Start()
        {
            // create a command queue
            _commandQueue = new CommandQueue();
            StartCommands();
        }

        public void StartCommands()
        {
            _commandQueue.Clear();
            // add commands
            _commandQueue.Enqueue(new FirstCmd(this));
            _commandQueue.Enqueue(new SecondCmd(this));
            _commandQueue.Enqueue(new ThirdCmd(this));
            Debug.Log("Commands enqueued");
        }
    }
}