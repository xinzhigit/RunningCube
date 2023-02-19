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

        public event Action OnMoveEnd;
        
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
            _inputPosition = UnityEngine.Input.mousePosition;
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                if (!_input)
                {
                    _prevPosition = _inputPosition;
                }
                _input = true;
                
                Debug.Log($"Input on mouse down {_inputPosition} {_prevPosition}");
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                _input = false;
                
                Debug.Log($"Input on mouse up {_inputPosition} {_prevPosition}");
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
                Debug.Log($"Input pos:{_inputPosition} _prev:{_prevPosition}");
                
                float normalizedDeltaPosition = (_inputPosition.x - _prevPosition.x) / Screen.width * inputSensitivity;
                OnMove?.Invoke(normalizedDeltaPosition);
            }
            else
            {
                OnMoveEnd?.Invoke();
            }
            
            _prevPosition = _inputPosition;
        }
    }
}
