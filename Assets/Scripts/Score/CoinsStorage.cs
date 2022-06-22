using Clicker.SaveSystem;

namespace Clicker.GameLogic
{
    public sealed class CoinsStorage
    {
        private IStorage _storage = new BinaryStorage();
        private const string Path = "CoinsCount.txt";
        private int _coinsCount;

        public int Load()
        {
            if (_storage.Exists(Path))
            {
                _coinsCount = _storage.Load(Path, _coinsCount);
                return _coinsCount;
            }
            return 0;
        }

        public void Save(int count)
        {
            _storage.Save(Path, count);
        }
    }
}