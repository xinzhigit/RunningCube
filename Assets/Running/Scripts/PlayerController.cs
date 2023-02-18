using System;
using UnityEngine;

namespace Running.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] 
        private Transform player;

        [SerializeField] 
        private Transform leftClamp;

        [SerializeField] 
        private Transform rightClamp;

        [SerializeField] 
        private float forwardSpeed;

        [SerializeField] 
        private float horizonSpeed;

        private Vector3 _leftClamp;
        private Vector3 _rightClamp;

        private Vector3 _bornPos;

        private bool _startMove;

        private Vector3 _curPos;

        public void StartMove()
        {
            _startMove = true;
        }
        
        private void Awake()
        {
            _bornPos = player.position;
            _curPos = _bornPos;

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

            var realDelta = delta * Time.deltaTime * horizonSpeed;
            _curPos.x += realDelta;
            _curPos.x = Mathf.Clamp(_curPos.x, _leftClamp.x, _rightClamp.x);
            
            Debug.Log($"Player controller input move delta:{delta} speed:{horizonSpeed} realDelta:{realDelta}");
        }
        
        private void UpdateMove()
        {
            if (!_startMove)
            {
                return;
            }
            
            _curPos.z += Time.deltaTime * forwardSpeed;

            transform.position = _curPos;
        }
    }
}
