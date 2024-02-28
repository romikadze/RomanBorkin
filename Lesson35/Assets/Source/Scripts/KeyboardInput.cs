using System;
using UnityEngine;

namespace Source.Scripts
{
    public class KeyboardInput : MonoBehaviour
    {
        public Action OnJumpClicked;
        public Action OnAttackClicked;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnJumpClicked?.Invoke();
            if (Input.GetKeyDown(KeyCode.F))
                OnAttackClicked?.Invoke();
        }
    }
}