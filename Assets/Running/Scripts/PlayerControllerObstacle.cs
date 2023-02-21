using System;
using System.Collections.Generic;
using Running.Scripts.Obstacle;
using UnityEngine;
using Random = UnityEngine.Random;

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

        private List<Transform> _climbTrans = new List<Transform>(20);
        public void ObstacleEnemy(ObstacleCube obstacleCube, ObstacleEnemy obstacleEnemy)
        {
            _climbTrans.Clear();
            for (int i = 0; i < obstacleCube.ClimbPoints.Length; ++i)
            {
                _climbTrans.Add(obstacleCube.ClimbPoints[i]);
            }
            
            for (int i = 0; i < obstacleEnemy.Enemies.Length; ++i)
            {
                var index = Random.Range(0, _climbTrans.Count);
                var clampPoint = _climbTrans[index];

                var enemy = obstacleEnemy.Enemies[i];
                enemy.ToClimb(clampPoint);
                
                _climbTrans.RemoveAt(index);
            }
            
            _climbTrans.Clear();
            // Debug.Log($"Player controller obstacle enemies {obstacleEnemy.Enemies.Length}");
        }
    }
}
