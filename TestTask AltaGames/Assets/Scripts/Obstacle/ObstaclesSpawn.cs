using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _obstaclePrefab;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _amountObstacles;
    [SerializeField] private float _radiusObstacle;
    [SerializeField] private LayerMask _layerMaskObstacle;
    private List<Transform> _transformsPoint = new List<Transform>();

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
       // int j = 0;
        for (int i = 0, j = 0; i < _amountObstacles && j < 1000; i++, j++)
        {
            Vector3 randomCirclePoint = UnityEngine.Random.insideUnitCircle * _spawnRadius;
            Vector3 spawnPoint = new Vector3(randomCirclePoint.x + _spawnPoint.position.x, _spawnPoint.position.y, randomCirclePoint.y + _spawnPoint.position.z);

            float randomRotationY = UnityEngine.Random.Range(0f, 360f);
            var spawnedObstacle =  Instantiate(_obstaclePrefab, spawnPoint, Quaternion.Euler(0, randomRotationY,0 ));
            _transformsPoint.Add(spawnedObstacle);
            Collider[] colliders = Physics.OverlapSphere(spawnedObstacle.position, _radiusObstacle, _layerMaskObstacle);

            if (colliders.Length > 1)
            {
                Destroy(spawnedObstacle.gameObject);
                _amountObstacles++;
            }
        }
    }
}
