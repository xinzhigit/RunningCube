using System;
using UnityEngine;

namespace Running.Scripts
{
    [RequireComponent(typeof(Camera))]
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        private Camera _camera;

        private Vector3 _relativePos;

        private void Awake()
        {
            _camera = GetComponent<Camera>();

            _relativePos = player.position - _camera.transform.position;
        }

        private void Update()
        {
            _camera.transform.position = player.position - _relativePos;
        }
    }
}
