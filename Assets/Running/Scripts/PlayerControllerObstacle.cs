using System;
using System.Collections.Generic;
using Running.Scripts.Obstacle;
using UnityEngine;

namespace Running.Scripts
{
    public partial class PlayerController
    {
        private float _playerCubeHeightDiff;
        
        public void ObstacleCube(Transform cube)
        {
            if (cubes.Contains(cube))
            {
                return;
            }
            
            var last = cubes[^1];
            cube.parent = last.parent;
            cube.position = last.position;
 
            for (int i = 0; i < cubes.Count; ++i)
            {
                var tempCube = cubes[i];
                var pos = tempCube.position;
                pos.y += cubeHeight;
                tempCube.position = pos;
            }

            cubes.Add(cube);
            
            // 更新角色位置
            var firstCube = cubes[0];
            var firstPos = firstCube.position;
            firstPos.y += _playerCubeHeightDiff;
            player.position = firstPos;
            
            Debug.Log("Player controller obstacle cube");
        }

        public void ObstacleEnemy(ObstacleEnemy enemy)
        {
            Debug.Log($"Player controller obstacle enemies {enemy.Enemies.Length}");
        }
    }
}
