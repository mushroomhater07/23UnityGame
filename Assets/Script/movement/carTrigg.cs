using UnityEngine;

namespace script
{
    public class carTrigg : MonoBehaviour
    {
        [SerializeField] private GameObject prompt, camCam, bodyCam,crosshair;
        private CharacterController char1;
        public bool entered { get; set; }
        private InputMan inputmgr;
        private float yPos =0f, turnSpeed = -5f;

        private void Start()
        {
            inputmgr = FindObjectOfType<InputMan>();
            char1 = FindObjectOfType<CharacterController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            prompt.SetActive(true);
            inputmgr.inputAction.nearCar.Enable();
            inputmgr.inputAction.nearCar.onCar.started += ctx => GetOnCar();
        }

        private void OnTriggerExit(Collider other)
        {
            entered = false;
            prompt.SetActive(false);
            inputmgr.inputAction.nearCar.Disable();
        }

        private void FixedUpdate()
        {
            Look(inputmgr.inputAction.onCar.Look.ReadValue<Vector2>());
            Drive(inputmgr.inputAction.onCar.Drive.ReadValue<Vector2>());
        }

        void Drive(Vector2 turning)
        {
            
            var newPos = transform.position + transform.TransformDirection(turning.y * Vector3.forward);
            transform.position = newPos;
            if (turning.y > 0) turnSpeed = Mathf.Abs(turnSpeed);
            if(turning.y != 0) transform.Rotate(Vector3.up * turning.x* turnSpeed);
        }

        void Look(Vector2 around)
        {
            yPos += around.x;
            yPos = Mathf.Clamp(yPos, -35f, 35f);
            if(yPos > -35f && yPos < 35f) camCam.transform.RotateAround(transform.position,Vector3.up, around.x);
            camCam.transform.localRotation = Quaternion.Euler(0, yPos, 0);
            
        }
        private void GetOnCar()
        {
            char1.gameObject.transform.parent= transform;
            crosshair.SetActive(false);
            bodyCam.SetActive(false);
            camCam.SetActive(true);
            inputmgr.inputAction.onFoot.Disable();
            inputmgr.inputAction.onCar.Enable();
            char1.gameObject.transform.position = transform.position;
            inputmgr.inputAction.onCar.offCar.started += ctx => LeaveCar();
        }
        private void LeaveCar()
        {
            char1.gameObject.transform.parent= null;
            crosshair.SetActive(true);
            bodyCam.SetActive(true);
            camCam.SetActive(false);
            inputmgr.inputAction.onFoot.Enable();
            inputmgr.inputAction.onCar.Disable();
            char1.gameObject.transform.position = transform.position;
        }
    }
}