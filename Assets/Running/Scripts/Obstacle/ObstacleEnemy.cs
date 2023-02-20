using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class ObstacleEnemy : MonoBehaviour
    {
        private static int _enemyLayer;
        
        public Enemy[] Enemies { private set; get; }
        
        private void Awake()
        {
            _enemyLayer = LayerMask.NameToLayer("Enemies");
            
            Enemies = GetComponentsInChildren<Enemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != _enemyLayer)
            {
                return;
            }
            
            Game.Inst.PlayerController.ObstacleEnemy(other.GetComponent<ObstacleEnemy>());
            
            // Debug.Log($"Obstacle cube on trigger enter {other.name}");
        }
    }
}
