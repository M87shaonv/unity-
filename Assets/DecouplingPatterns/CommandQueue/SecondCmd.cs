using UnityEngine;

namespace DecouplingPatterns.CommandQueue
{
    public class SecondCmd : BaseCommand
    {
        public SecondCmd(GameController owner) : base(owner) { }

        public override void Execute()
        {
            _owner.secondPopup.gameObject.SetActive(true);
            _owner.secondPopup.onClose += OnClose;
            Debug.Log("Second command executed");
        }

        protected override void OnClose()
        {
            _owner.secondPopup.onClose -= OnClose;
            _owner.secondPopup.gameObject.SetActive(false);
            OnFinished?.Invoke();
            Debug.Log("Second command finished");
        }
    }
}