using UnityEngine;
using Zenject;

namespace Clicker.GameLogic
{
    [RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public abstract class Balloon : MonoBehaviour
    {
        public AnimationCurve CurveFromTime => _curveFromTime;
        [SerializeField] private AnimationCurve _curveFromTime;
        [SerializeField] private AudioClip _catchClip;
        private SpriteRenderer _spriteRenderer;
        private AudioSource _catchSound;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        protected AudioClip CatchClip => _catchClip;
        protected CoinsCollector Collector { get; private set; }

        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();

        [Inject]
        public void Init(CoinsCollector collector, AudioSource audioSource)
        {
            Collector = collector;
            _catchSound = audioSource;
        }

        public void Disable() => _spriteRenderer.enabled = false;

        public abstract void Apply();

        protected void PlaySound(AudioClip audio) => _catchSound.PlayOneShot(audio);
    }

}
