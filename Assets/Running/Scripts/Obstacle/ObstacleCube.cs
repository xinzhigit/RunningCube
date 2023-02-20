using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class ObstacleCube : MonoBehaviour
    {
        private static int _layer;

        private void Awake()
        {
            _layer = LayerMask.NameToLayer("Cube");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != _layer)
            {
                return;
            }
            
            Game.Inst.PlayerController.ObstacleCube(other.transform);
            
            // Debug.Log($"Obstacle cube on trigger enter {other.name}");
        }
    }
}
