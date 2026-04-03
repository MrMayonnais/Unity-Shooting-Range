using UnityEngine;

namespace Project_Files.Scripts.Player.Input
{
    public class InputLock
    {
        private readonly MonoBehaviour _lockEmitter;
        private readonly LockStorage _storage;

        public InputLock(MonoBehaviour lockEmitter, LockStorage storage)
        {
            _lockEmitter = lockEmitter;
            _storage = storage;
        }

        public MonoBehaviour GetEmitter()
        {
            return _lockEmitter;
        }

        public virtual void ReleaseLock()
        {
            _storage.RemoveLock(this);
        }

    }
}