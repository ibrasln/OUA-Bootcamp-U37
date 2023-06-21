using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool DashInput { get; private set; }
        public bool AttackInput { get; private set; }

        public void OnMove(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();
            NormInputX = Mathf.RoundToInt(RawMovementInput.normalized.x);
            NormInputY = Mathf.RoundToInt(RawMovementInput.normalized.y);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.started)
                JumpInput = true;
            else if (context.canceled)
                JumpInput = false;
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.started)
                DashInput = true;
            else if (context.canceled)
                DashInput = false;
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.started)
                AttackInput = true;
            else if (context.canceled)
                AttackInput = false;
        }

        public void UseJumpInput() => JumpInput = false;
        public void UseDashInput() => DashInput = false;
    }
}
