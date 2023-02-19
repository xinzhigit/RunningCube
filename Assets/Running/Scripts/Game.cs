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
            Application.targetFrameRate = 60;
            
            input.OnMove += playerController.OnInputMove;
            input.OnMoveEnd += playerController.OnInputEnd;
            
            playerController.StartMove();
        }

        private void OnDestroy()
        {
            input.OnMove -= playerController.OnInputMove;
            input.OnMoveEnd -= playerController.OnInputEnd;
        }
    }
}
