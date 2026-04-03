using System.Collections.Generic;
using UnityEngine;

namespace Project_Files.Scripts.Player.Input
{
    public class LockStorage
    {
        private List<InputLock> _acquiredLocks = new List<InputLock>();
        
        private void AddLock(InputLock lockToAdd)
        {
            _acquiredLocks.Add(lockToAdd);
        }
        public void RemoveLock(InputLock lockToRemove)
        {
            _acquiredLocks.Remove(lockToRemove);
        }

        public InputLock GetLock(InputType type, MonoBehaviour lockEmitter)
        {
            var newLock = new SimpleLock(type, lockEmitter, this);
            AddLock(newLock);
            return newLock;
        }
        
        public InputLock GetLock(InputGroup group, MonoBehaviour lockEmitter)
        {
            var newLock = new CompositeLock(lockEmitter, group, this);
            AddLock(newLock);
            return newLock;
        }
        public bool IsTypeLocked(InputType typeToCheck)
        {
            foreach (InputLock inputLock in _acquiredLocks)
            {
                if (inputLock is CompositeLock compositeLock)
                {
                    if (compositeLock.IsTypeLocked(typeToCheck))
                    {
                        return true;
                    }
                }
                else if (inputLock is SimpleLock simpleLock)
                {
                    if (simpleLock.GetInputType() == typeToCheck)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}