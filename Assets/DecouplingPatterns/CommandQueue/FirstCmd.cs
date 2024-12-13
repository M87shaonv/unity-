using UnityEngine;

namespace DecouplingPatterns.CommandQueue
{
    public class FirstCmd : BaseCommand
    {
        public FirstCmd(GameController owner) : base(owner) { }

        public override void Execute()
        {
            _owner.firstPopUp.gameObject.SetActive(true); //Activate the first pop-up window and subscribe to its closing event
            _owner.firstPopUp.onClose += OnClose;
            Debug.Log("Executing First Command");
        }

        protected override void OnClose()
        {
            _owner.firstPopUp.onClose -= OnClose; //Remove subscriptions to close events to prevent memory leaks
            _owner.firstPopUp.gameObject.SetActive(false);
            OnFinished?.Invoke();
            Debug.Log("First Command Finished");
        }
    }
}