using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class ObstacleEnemy : MonoBehaviour
    {
        public Enemy[] Enemies { private set; get; }
        
        private void Awake()
        {
            Enemies = GetComponentsInChildren<Enemy>();
        }
    }
}
