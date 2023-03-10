using System;
using System.Collections.Generic;
using UnityEngine;

namespace Running.Scripts
{
    public partial class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        [SerializeField] private Transform cubeParent;
        
        [SerializeField] private List<Transform> cubes;

        [SerializeField] private float cubeHeight;
        
        [SerializeField] private Transform leftClamp;

        [SerializeField] private Transform rightClamp;

        [SerializeField] private float speed;

        [SerializeField] private float horizonSpeedFactor;

        private Vector3 _leftClamp;
        private Vector3 _rightClamp;

        private bool _startMove;
        // private bool _input;

        private Vector3 _curPos;
        private float _targetX;

        private void Awake()
        {
            _curPos = transform.position;
            _targetX = _curPos.x;

            _leftClamp = leftClamp.position;
            _rightClamp = rightClamp.position;

            var firstCube = cubes[0];
            _playerCubeHeightDiff = player.position.y - firstCube.position.y;
        }

        private void Update()
        {
            UpdateMove();
        }

        #region move

        public void OnInputMove(float delta)
        {
            if (!_startMove)
            {
                return;
            }

            var width = _rightClamp.x - _leftClamp.x;
            _targetX += delta * width;
            _targetX = Mathf.Clamp(_targetX, _leftClamp.x, _rightClamp.x);
            
            var horizonSpeed = speed * horizonSpeedFactor;
            float posTarget = Mathf.Lerp(_curPos.x, _targetX, horizonSpeed);
            float posDifference = posTarget - _curPos.x;

            posDifference = Mathf.Clamp(posDifference, -horizonSpeed, horizonSpeed);

            _curPos.x += posDifference;

            // _input = true;

            // Debug.Log($"Player controller input move delta:{delta}");
        }

        public void OnInputEnd()
        {
            // _input = false;
        }
        
        public void StartMove()
        {
            _startMove = true;
        }
        
        private void UpdateMove()
        {
            if (!_startMove)
            {
                return;
            }

            var moveDelta = Time.deltaTime * speed;
            _curPos.z += moveDelta;

            // if (_input)
            // {
            //
            // }
            
            transform.position = _curPos;
            
            // Debug.Log($"Player controller update delta:{Time.deltaTime} {speed} {moveDelta} {_curPos}");
        }

        #endregion
    }
}
