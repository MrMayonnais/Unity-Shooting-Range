using UnityEngine;
using UnityEngine.InputSystem;

namespace Project_Files.Scripts.Player.Input
{
    public class PlayerInputDispatcher : MonoBehaviour
    {
        //--------------------INPUT DISPATCHING--------------------//

        public void OnMove(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Movement)) return;
            PlayerInputEvents.OnMoveInput?.Invoke(action.ReadValue<Vector2>());
        }

        public void OnLook(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Look)) return;
            PlayerInputEvents.OnLookInput?.Invoke(action.ReadValue<Vector2>());
        }
        
        public void OnJump(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Jump)) return;
            PlayerInputEvents.OnJumpInput?.Invoke(action.ReadValueAsButton());
        }

        public void OnCrouch(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Crouch)) return;
            PlayerInputEvents.OnCrouchInput?.Invoke(action.ReadValueAsButton());
        }
        
        public void OnSprint(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Sprint)) return;
            PlayerInputEvents.OnSprintInput?.Invoke(action.ReadValueAsButton());
        }

        public void OnAim(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Aim)) return;
            PlayerInputEvents.OnAimInput?.Invoke(action.ReadValueAsButton());
        }
        
        public void OnFire(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Fire)) return;
            PlayerInputEvents.OnFireInput?.Invoke(action.ReadValueAsButton());
        }
        
        public void OnReload(InputAction.CallbackContext action)
        {
            if(IsInputLocked(InputType.Reload)) return;
            PlayerInputEvents.OnReloadInput?.Invoke(action.ReadValueAsButton());
        }

        //--------------------LOCKING SYSTEM--------------------//
        
        private static readonly LockStorage LockStorage = new LockStorage();
        
        public static LockStorage GetLockStorage()
        {
            return LockStorage;
        }
        private static bool IsInputLocked(InputType inputType)
        {
            return LockStorage.IsTypeLocked(inputType);
        }
    }
}
