using System;
using UnityEngine;

namespace Project_Files.Scripts.Player.Input
{
    public abstract class PlayerInputEvents
    {
        public static Action<Vector2> OnMoveInput;
        public static Action<Vector2> OnLookInput;
    
        public static Action<bool> OnJumpInput;
        public static Action<bool> OnCrouchInput;
        public static Action<bool> OnSprintInput;
        public static Action<bool> OnAimInput;
        public static Action<bool> OnFireInput;
        public static Action<bool> OnReloadInput;
    }
}
