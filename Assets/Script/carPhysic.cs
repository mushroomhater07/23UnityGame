using System;
using UnityEngine;

namespace script
{
    public class carPhysic : MonoBehaviour
    {
        [SerializeField] private WheelCollider[] wheels;
        private float motorPower = 100, steerPower = 100;

        private InputMan inputmgr;
        private GameObject centerOfMass;
        private Rigidbody rb;

        private void Start()
        {
            inputmgr = FindObjectOfType<InputMan>();
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = centerOfMass.transform.localPosition;
        }

        private void FixedUpdate()
        {
            var value = inputmgr.inputAction.onCar.Drive.ReadValue<Vector2>();
            foreach (var wheel in wheels) wheel.motorTorque = value.y * ((motorPower * 5) / 4);
            for (int i = 0; i < wheels.Length; i++)
            {
                if (i < 2)
                    wheels[i].steerAngle = value.x;
            }
        }
    }
}