using System;
using UnityEngine;

namespace DecouplingPatterns.CommandQueue
{
    //Represents a user interface component that can be displayed and closed
    public class Popup : MonoBehaviour
    {
        public Action onClose;

        public void Close()
        {
            onClose?.Invoke();
        }
    }
}