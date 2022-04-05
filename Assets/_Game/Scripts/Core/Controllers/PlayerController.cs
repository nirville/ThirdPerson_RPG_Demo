using UnityEngine;
using System.Collections;

namespace Nirville
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Properties")]
        // [SerializeField] int playerNumber = 1;
        [SerializeField] float moveSpeed = 2;
        [SerializeField] float turnSpeed = 4;
        [SerializeField] float jumpForce = 4;
        [SerializeField] float GroundedOffset = -0.14f;
        [SerializeField] LayerMask groundLayer;

        public bool isGrounded = true;

        Rigidbody playerRigibody;

        float horizontalInput;
        float verticalInput;

        string horizontalAxisName;
        string verticalAxisName;

        void Awake()
        {
            playerRigibody = GetComponent<Rigidbody>();
        }

        void OnEnable()
        {
            horizontalInput = 0;
            verticalInput = 0;
        }

        void Start()
        {
            horizontalAxisName = "Horizontal";
            verticalAxisName = "Vertical";
        }

        void Update()
        {
            
            //Input Axes for WASD movement
            horizontalInput = Input.GetAxis(horizontalAxisName);
            verticalInput = Input.GetAxis(verticalAxisName);

            //KeyboardInputs for registering Animations
            if (Input.GetButtonDown("Jump") && isGrounded) Jump();
            if (Input.GetButtonDown("Vertical")) AnimationEvents.current.WalkForward();
            if (Input.GetButtonUp("Vertical")) AnimationEvents.current.Idle();
        }

        void FixedUpdate()
        {
            Move();
            Turn();
            GroundedCheck();
        }

        private void Move()
        {
            Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
            playerRigibody.MovePosition(playerRigibody.position + movement);
        }

        private void Turn()
        {
            float turn = horizontalInput * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            playerRigibody.MoveRotation(playerRigibody.rotation * turnRotation);
        }

        private void Jump()
        {
            StartCoroutine(Jump());
            IEnumerator Jump()
            {
                float jumpTimer = 0;
                while (jumpTimer < 0.2f)
                {
                    jumpTimer += Time.deltaTime;
                    yield return null;
                }
                playerRigibody.AddForce(Vector3.up * jumpForce + (transform.forward * 0.125f), ForceMode.Impulse);
                jumpTimer = 0;
                yield return null;
            }
        }

        private void GroundedCheck()
        {
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
            isGrounded = Physics.CheckSphere(spherePosition, 0.5f, groundLayer, QueryTriggerInteraction.Ignore);
        }
    }

}
