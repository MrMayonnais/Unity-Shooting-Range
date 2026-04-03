using System.Collections.Generic;

namespace Project_Files.Scripts.Player
{
    public class InputType
    {
        private InputGroup _inputGroup;
        
        public InputType(InputGroup inputGroup)
        {
            _inputGroup = inputGroup;
        }

        public static readonly InputType Movement = new InputType(InputGroup.MovementInput);
        public static readonly InputType Jump = new InputType(InputGroup.MovementInput);
        public static readonly InputType Sprint = new InputType(InputGroup.MovementInput);
        public static readonly InputType Crouch = new InputType(InputGroup.MovementInput);
        
        public static readonly InputType Fire = new InputType(InputGroup.WeaponInput);
        public static readonly InputType Reload = new InputType(InputGroup.WeaponInput);
        public static readonly InputType Aim = new InputType(InputGroup.WeaponInput);
        
        public static readonly InputType Look = new InputType(InputGroup.LookInput);
        
        private static List<InputType> AllInputTypes = new List<InputType>()
        {
            Movement, Jump, Sprint, Crouch,
            Fire, Reload, Aim,
            Look
        };

        public static List<InputType> GetInputTypesInGroup(InputGroup group)
        {
            var typesInGroup = new List<InputType>();
            foreach (var inputType in AllInputTypes)
            {
                if (inputType._inputGroup == group)
                {
                    typesInGroup.Add(inputType);
                }
            }

            return typesInGroup;
        }
    }
}