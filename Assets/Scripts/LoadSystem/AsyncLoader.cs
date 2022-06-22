using UnityEngine.AddressableAssets;

namespace Clicker.LoadSystem
{
    public sealed class AsyncLoader : ILoader
    {
        private AssetReference _scene;

        public AsyncLoader(AssetReference scene)
        {
            _scene = scene;
        }

        public void Load(SceneData sceneData)
        {
            _scene.LoadSceneAsync();
        }
    }
}
