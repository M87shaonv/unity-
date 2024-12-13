using UnityEngine;

namespace DecouplingPatterns.CommandQueue
{
    public class ThirdCmd : BaseCommand
    {
        public ThirdCmd(GameController owner) : base(owner) { }

        public override void Execute()
        {
            _owner.thirdPopup.gameObject.SetActive(true);
            _owner.thirdPopup.onClose += OnClose;
            Debug.Log("Third command executed");
        }

        protected override void OnClose()
        {
            _owner.thirdPopup.onClose -= OnClose;
            _owner.thirdPopup.gameObject.SetActive(false);
            OnFinished?.Invoke();
            Debug.Log("Third command finished");
        }
    }
}