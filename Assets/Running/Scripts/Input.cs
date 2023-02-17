using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Running.Scripts
{
    public class Input : MonoBehaviour
    {
        /// <summary>
        /// 左右移动
        /// </summary>
        public event Action<float> OnMove;
        
        [SerializeField]
        private float inputSensitivity = 1.5f;

        private bool _input;

        private Vector3 _inputPosition;
        private Vector3 _prevPosition;

        public void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
#if UNITY_EDITOR
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _inputPosition = UnityEngine.Input.mousePosition;
                
                if (!_input)
                {
                    _prevPosition = _inputPosition;
                }
                _input = true;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                _input = false;
            }
#else
            if (Touch.activeTouches.Count > 0)
            {
                _inputPosition = Touch.activeTouches[0].screenPosition;

                if (!_input)
                {
                    _prevPosition = _inputPosition;
                }
                
                _input = true;
            }
            else
            {
                _input = false;
            }
#endif
            if (_input)
            {
                float normalizedDeltaPosition = (_inputPosition.x - _prevPosition.x) / Screen.width * inputSensitivity;
                OnMove?.Invoke(normalizedDeltaPosition);
            }
            _prevPosition = _inputPosition;
        }
    }
}
