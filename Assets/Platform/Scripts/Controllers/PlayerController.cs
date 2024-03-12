using System;
using UnityEngine;

namespace Platformer
{
    /// <summary>
    /// Manages a character. Allows keyboard input.
    /// </summary>
    [RequireComponent(typeof(CharacterMotor))]
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// Object to activate and deactivate depending if there is an action to perform by the motor.
        /// </summary>
        [Tooltip("Object to activate and deactivate depending if there is an action to perform by the motor.")]
        public GameObject ActionUI;

        internal bool HasMovement;
        internal Vector2 Movement;
        private CharacterMotor motor;

private bool isPaused = false;

        private void Start()
        {
            motor = GetComponent<CharacterMotor>(); // Get the CharacterMotor component
            if (motor == null)
            {
                Debug.LogError("CharacterMotor not found on the same GameObject as PlayerController.");
                enabled = false; // Disable this script if CharacterMotor is not found
            }
        }
    public void Pause()
    {
        // Pause specific functionalities here
        isPaused = true;
        // For example:
        // Stop player movement, animations, etc.
    }

    // Method to resume functionalities in the PlayerController
    public void Resume()
    {
        // Resume specific functionalities here
        isPaused = false;
        // For example:
        // Allow player movement, resume animations, etc.
    }

        private void Update()
        {
            Characters.MainPlayer = Characters.Get(gameObject);

            var motor = GetComponent<CharacterMotor>();
            if (motor == null)
                return;

            if (ActionUI != null)
                if (ActionUI.activeSelf != (motor.Action != null))
                    ActionUI.SetActive(motor.Action != null);

            if (motor.IsFalling)
                motor.StandUp();
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && !motor.IsHangingOnEdge)
                    motor.InputAttack();

                if (Input.GetKey(KeyCode.UpArrow) || (HasMovement && Movement.y > 0.05f))
                    motor.InputClimb(1);

                if (Input.GetKey(KeyCode.DownArrow) || (HasMovement && Movement.y < -0.05f))
                    motor.InputClimb(-1);

                if (Input.GetKey(KeyCode.LeftArrow) || (HasMovement && Movement.x < -0.05f))
                {
                    motor.InputMovement(-1);

                    if (!motor.IsHangingOnRope)
                        if (motor.IsOnWalkableSurface || !motor.IsGrounded)
                            motor.Direction = CharacterDirection.Left;
                }

                if (Input.GetKey(KeyCode.RightArrow) || (HasMovement && Movement.x > 0.05f))
                {
                    motor.InputMovement(1);

                    if (!motor.IsHangingOnRope)
                        if (motor.IsOnWalkableSurface || !motor.IsGrounded)
                            motor.Direction = CharacterDirection.Right;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                    motor.InputJump();
            }
        }
        
    }
}
