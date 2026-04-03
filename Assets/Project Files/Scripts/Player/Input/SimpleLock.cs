using Project_Files.Scripts.Player.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project_Files.Scripts.Player
{
    public class SimpleLock: InputLock
    {
        private InputType _type;
        
        public SimpleLock(InputType type, MonoBehaviour lockEmitter, LockStorage storage) : base(lockEmitter, storage) {}
        
        public InputType GetInputType()
        {
            return _type;
        }
    }
}