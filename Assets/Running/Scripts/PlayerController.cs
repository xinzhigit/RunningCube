using System;
using System.Collections.Generic;
using UnityEngine;

namespace Running.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform cubeParent;
        
        [SerializeField] private List<Transform> cubes;

        [SerializeField] private Transform leftClamp;

        [SerializeField] private Transform rightClamp;

        [SerializeField] private float speed;

        [SerializeField] private float horizonSpeedFactor;

        private Vector3 _leftClamp;
        private Vector3 _rightClamp;

        private bool _startMove;
        private bool _input;

        private Vector3 _curPos;
        private float _targetX;

        public void StartMove()
        {
            _startMove = true;
        }
        
        private void Awake()
        {
            _curPos = transform.position;
            _targetX = _curPos.x;

            _leftClamp = leftClamp.position;
            _rightClamp = rightClamp.position;
        }

        private void Update()
        {
            UpdateMove();
        }

        public void OnInputMove(float delta)
        {
            if (!_startMove)
            {
                return;
            }

            var width = _rightClamp.x - _leftClamp.x;
            _targetX += delta * width;
            _targetX = Mathf.Clamp(_targetX, _leftClamp.x, _rightClamp.x);

            _input = true;

            // Debug.Log($"Player controller input move delta:{delta}");
        }

        public void OnInputEnd()
        {
            _input = false;
        }
        
        private void UpdateMove()
        {
            if (!_startMove)
            {
                return;
            }

            var moveDelta = Time.deltaTime * speed;
            _curPos.z += moveDelta;

            if (_input)
            {
                var horizonSpeed = speed * horizonSpeedFactor;
                float newPositionTarget = Mathf.Lerp(_curPos.x, _targetX, horizonSpeed);
                float newPositionDifference = newPositionTarget - _curPos.x;

                newPositionDifference = Mathf.Clamp(newPositionDifference, -horizonSpeed, horizonSpeed);

                _curPos.x += newPositionDifference;
            }
            
            transform.position = _curPos;
            
            Debug.Log($"Player controller update delta:{Time.deltaTime} {speed} {moveDelta} {_curPos}");
        }
    }
}
