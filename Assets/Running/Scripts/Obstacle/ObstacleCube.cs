using System;
using System.Collections.Generic;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class ObstacleCube : MonoBehaviour
    {
        [SerializeField] private float size;
        public float Size => size;
        
        private static int _cubeLayer;
        private static int _enemyLayer;

        public Transform[] ClimbPoints { private set; get; }

        private void Awake()
        {
            _cubeLayer = LayerMask.NameToLayer("Cube");
            _enemyLayer = LayerMask.NameToLayer("Enemies");

            ClimbPoints = GetComponentsInChildren<Transform>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var playerController = Game.Inst.PlayerController;
            
            if (other.gameObject.layer == _cubeLayer)
            {
                playerController.ObstacleCube(other.transform);
            }
            else if (other.gameObject.layer == _enemyLayer)
            {
                playerController.ObstacleEnemy(this, other.GetComponent<ObstacleEnemy>());
            }

            // Debug.Log($"Obstacle cube on trigger enter {other.name}");
        }
    }
}
