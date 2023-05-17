using System;
using UnityEngine;

namespace script
{
    public class InputMan : MonoBehaviour
    {
        private InputMap _inputAction;
        public InputMap inputAction => _inputAction;
        
        private bool mouselockstate = false;
        
        private void Awake() {
            _inputAction = new InputMap();
            _inputAction.always.Enable();
            _inputAction.always.Hook.started += ctx => LockMouse();
        }
        private void LockMouse() {
            if (mouselockstate) {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                mouselockstate = false;
            }else {// Screen.lockCursor = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                mouselockstate = true;
            }
        }
    }
}