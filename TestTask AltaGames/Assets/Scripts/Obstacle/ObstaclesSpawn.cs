using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private int _amountObstacles;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < _amountObstacles; i++)
        {
            Vector3 randomCirclePoint = UnityEngine.Random.insideUnitCircle.normalized * _spawnRadius;
            Vector3 spawnPoint = new Vector3(randomCirclePoint.x + _spawnPoint.position.x, _spawnPoint.position.y, randomCirclePoint.y + _spawnPoint.position.z);
            Instantiate(_obstaclePrefab, spawnPoint, Quaternion.identity);

          
        }
    }
}
