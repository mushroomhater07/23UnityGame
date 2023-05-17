using UnityEngine.UI;
using UnityEngine;

namespace script
{
    public class CamMan : MonoBehaviour
    {
        [SerializeField] private Transform target;
        Vector3 _offset, currentSpeed = Vector3.zero;
        [SerializeField] private float smoothTime;
        private Camera cam;
        private void Awake() {_offset = transform.position - target.position;
            cam = GetComponent<Camera>();
        }
        private void LateUpdate()
        {   var targetpos = target.position + _offset;
            transform.position = targetpos;
            // Vector3.SmoothDamp(transform.position, targetpos, ref currentSpeed, smoothTime);
            transform.rotation = target.rotation;
        }       
    }
}