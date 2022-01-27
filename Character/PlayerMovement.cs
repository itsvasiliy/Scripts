using UnityEngine;

namespace Assets.Scripts.Character
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick movementJoystick;

        [SerializeField] private CharacterController characterController;

        [SerializeField] private Transform bodyTransform;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float gravityForce;

        private Vector3 moveVector3;

        private void FixedUpdate()
        {
            CharacterMove();
            RotationOfCharacter();
            GamingGravity();
        }

        private void CharacterMove()
        {
            moveVector3 = Vector3.zero;

            moveVector3.x = movementJoystick.Horizontal * moveSpeed;
            moveVector3.z = movementJoystick.Vertical * moveSpeed;

            moveVector3.y = gravityForce;
            characterController.Move(moveVector3 * Time.deltaTime);
        }

        private void RotationOfCharacter()
        {
            if (movementJoystick.Direction != Vector2.zero)
            {
                Vector3 direction = new Vector3(movementJoystick.Direction.x, 0f, movementJoystick.Direction.y);
                Quaternion rotation = Quaternion.LookRotation(direction);
                bodyTransform.rotation = rotation;
            }
        }

        private void GamingGravity()
        {
            if (!characterController.isGrounded)
                gravityForce -= 20f * Time.deltaTime;
            else
                gravityForce = -1f;
        }
    }
}