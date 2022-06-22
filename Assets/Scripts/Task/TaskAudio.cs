using UnityEngine;

namespace Clicker.GameLogic
{
    public sealed class TaskAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _wrongAudio;
        [SerializeField] private AudioSource _correctAudio;

        public void Play(bool correct)
        {
            if (correct)
                _correctAudio.Play();
            else
                _wrongAudio.Play();
        }
    }
}
