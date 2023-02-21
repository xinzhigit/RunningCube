using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class Enemy : MonoBehaviour
    {
        private Animator _animator;

        private Transform _trans;

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _trans = transform;
        }

        public void ToClimb(Transform transClimb)
        {
            // _trans.position = transClimb.position;
            // _trans.rotation = transClimb.rotation;
            _trans.parent = transClimb;
            _trans.localPosition = Vector3.zero;
            _trans.localRotation = Quaternion.identity;
        }
    }
}
