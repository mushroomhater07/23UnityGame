using UnityEngine.UI;
using UnityEngine;

namespace script
{
    public class Move : MonoBehaviour
    {
        private InputMap.OnFootActions footAction;
        private CharacterController char1;
        
        [SerializeField] private Camera cam;
        [SerializeField] private Slider xSensSlider, ySenSlider, fovSlider;
        private float xPos = 0;
        private bool fast, isGrounded, Jumped;

        public float _velocity, _gravity = -9.81f,JumpPower = 5f;
        private Vector3 _newPos;
        
        private void Start()
        {
            footAction = FindObjectOfType<InputMan>().inputAction.onFoot;
            char1 = GetComponent<CharacterController>();

            footAction.Enable();
            footAction.Fast.performed += ctx => fast = true;
            footAction.Fast.canceled += ctx => fast = false;
            footAction.Jump.performed += ctx => Jump();
        }
        private void FixedUpdate()
        {
            ProcessLook(footAction.LookAround.ReadValue<Vector2>());
        }
        private void LateUpdate()
        {
            ProcessMove(footAction.Walk.ReadValue<Vector2>(), fast);
        }
        void ProcessLook(Vector2 dir)
        {
            cam.fieldOfView = fovSlider.value;
            float xSens = xSensSlider.value, ySens = ySenSlider.value;
            xPos = Mathf.Clamp(xPos - dir.y * Time.deltaTime * ySens, -45f, 45f);
            cam.transform.localRotation = Quaternion.Euler(xPos * Vector3.right);
            transform.Rotate(Vector3.up * (dir.x * Time.deltaTime * xSens));
        }
        void ProcessMove(Vector2 dir, bool shiftboost)
        {
            int speed;
            if (shiftboost) speed = 12;
            else speed = 8;
            _newPos = new Vector3(dir.x* (speed * Time.deltaTime), Gravity()* Time.deltaTime, dir.y* (speed * Time.deltaTime)) ;
            char1.Move(transform.TransformDirection(_newPos));
        }
        float Gravity()
        {
            if (char1.isGrounded && _velocity < 0f) _velocity = -0.5f;
            else _velocity += _gravity * Time.deltaTime;
            return _velocity;
        }
        void Jump()
        {
            _velocity += JumpPower;
        } 
        // GetButton("fire")
            // playerInput.actions["fire"].IsPressed() == true?
        // GetButtonDown("fire")
            // playerInput.actions["fire"].WasPressedThisFrame()
        // GetButtonUp("fire")
            // playerInput.actions["fire"].WasReleasedThisFrame()
         // rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
         //playerVelocity.y = Mathf.Sqrt(jh * -3.0f * gravity);
    }
}