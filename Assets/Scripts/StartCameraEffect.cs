using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

namespace Clicker.GameLogic
{
    public sealed class StartCameraEffect : MonoBehaviour
    {
        [SerializeField] private PostProcessProfile _profile;

        private void Start() => StartCoroutine(Play(100, 0, 1.2f));

        private IEnumerator Play(float startValue, float endValue, float duration)
        {
            float elapsed = 0;
            float nextValue;

            if (_profile.TryGetSettings(out LensDistortion lensDistortion))
            {
                while (elapsed < duration)
                {
                    nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
                    lensDistortion.intensity.value = nextValue;
                    elapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}
