using System;
using UnityEngine;

namespace Running.Scripts
{
    public class Game : MonoBehaviour
    {
        public static Game Inst { get; private set; }

        [SerializeField] private Input input;

        [SerializeField] private PlayerController playerController;
        public PlayerController PlayerController => playerController;

        private void Awake()
        {
            Inst = this;
            
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
