using System;
using UnityEngine;

namespace Running.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] 
        private Input input;

        [SerializeField] 
        private PlayerController playerController;

        private void Awake()
        {
            input.OnMove += playerController.OnInputMove;
            
            playerController.StartMove();
        }

        private void OnDestroy()
        {
            input.OnMove -= playerController.OnInputMove;
        }
    }
}
