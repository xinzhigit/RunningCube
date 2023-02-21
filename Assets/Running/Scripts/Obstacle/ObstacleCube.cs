using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class ObstacleCube : MonoBehaviour
    {
        private static int _cubeLayer;
        private static int _enemyLayer;

        private void Awake()
        {
            _cubeLayer = LayerMask.NameToLayer("Cube");
            _enemyLayer = LayerMask.NameToLayer("Enemies");
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
                playerController.ObstacleEnemy(other.GetComponent<ObstacleEnemy>());
            }

            // Debug.Log($"Obstacle cube on trigger enter {other.name}");
        }
    }
}
