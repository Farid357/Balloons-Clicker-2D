using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Clicker.LoadSystem
{
    public sealed class SceneLoader : MonoBehaviour, ILoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private ScreenFade _screen;
        [SerializeField] private SceneData _loaderScene;
        [SerializeField] private AssetReference _nextScene;
        private ILoader[] _loaders;

        private void Start()
        {
            _loaders = new ILoader[]
            {
                new StandartLoader(),
                new FadeLoader(_screen),
                new LoaderWithScreen(_loaderScene),
                new AsyncLoader(_nextScene)
            };
        }

        public void Load(SceneData sceneData)
        {
            var modeIndex = (int) _mode;
            _loaders[modeIndex].Load(sceneData);
        }
    }

    public enum SceneLoadMode
    {
        Simple,
        Fade,
        WithLoadScreen,
        Async
    }

    public interface ILoader
    {
        public void Load(SceneData sceneData);
    }
}
