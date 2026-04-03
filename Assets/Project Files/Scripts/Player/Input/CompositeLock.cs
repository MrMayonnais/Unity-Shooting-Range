using System.Collections.Generic;
using UnityEngine;

namespace Project_Files.Scripts.Player.Input
{
    public class CompositeLock: InputLock
    {
        private List<InputLock> _boundLocks = new List<InputLock>();

        public CompositeLock(MonoBehaviour lockEmitter, InputGroup group, LockStorage storage) : base(lockEmitter, storage)
        {
            var inputTypesInGroup = InputType.GetInputTypesInGroup(group);
            foreach (InputType inputType in inputTypesInGroup)
            {
                _boundLocks.Add(new SimpleLock(inputType, lockEmitter, storage));
            }
        }
        public bool IsTypeLocked(InputType typeToCheck)
        {
            foreach (InputLock inputLock in _boundLocks)
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
    
        public void AddLock(InputLock lockToAdd)
        {
            _boundLocks.Add(lockToAdd);
        }
    
        public override void ReleaseLock()
        {
            foreach (InputLock inputLock in _boundLocks)
            {
                inputLock.ReleaseLock();
            }
            base.ReleaseLock();
        }
    }
}
