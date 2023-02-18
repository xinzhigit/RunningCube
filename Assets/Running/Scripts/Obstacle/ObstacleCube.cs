using System;
using UnityEngine;

namespace Running.Scripts.Obstacle
{
    public class ObstacleCube : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Obstacle cube on trigger enter {other.name}");
        }
    }
}
