using UnityEngine;

namespace FactoryPattern.SoundFactory
{
    public class SoundSystemOther : ISoundSystem
    {
        public bool PlaySound(int soundId)
        {
            Debug.Log($"Played the sound with id {soundId} on some other system");
            return true;
        }

        public bool StopSound(int soundId)
        {
            Debug.Log($"Stopped the sound with id {soundId} on some other system");
            return true;
        }
    }
}