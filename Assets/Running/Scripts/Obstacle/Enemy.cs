using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class Enemy : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
}
