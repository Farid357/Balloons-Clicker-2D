using Clicker.SaveSystem;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Clicker.GameLogic
{
    public sealed class AudioVolume : MonoBehaviour
    {

        [SerializeField] private AudioMixer _soundMixer;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private float _volume;

        private IStorage _storage = new PlayerPrefsStorage();
        private const string GroupName = "Master";
        private readonly AudioData _data = new();

        private void Start() => Init();

        private void Init()
        {
            _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
            var data = _storage.Load(GroupName, _data);
            if (data != null)
                _volume = data.Volume;
            _soundSlider.value = _volume;
            _soundMixer.SetFloat(GroupName, _volume);
        }

        private void OnDisable()
        {
            _soundSlider.onValueChanged.RemoveListener(ChangeSoundVolume);
        }

        private void ChangeSoundVolume(float volume)
        {
            _data.Volume = volume;
            _soundMixer.SetFloat(GroupName, volume);
            _storage.Save(GroupName, _data);
        }

        [System.Serializable]
        private sealed class AudioData
        {
            public float Volume;
        }
    }
}
