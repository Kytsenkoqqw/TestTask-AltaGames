using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public event Action OnPushBall;
    public GameObject BallPrefab;
    private Vector3 _positionSpawn;
    private GameObject _spawnedBall;

    private void Start()
    {
        _positionSpawn = new Vector3(transform.position.x + 6,transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBall();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnPushBall?.Invoke();
        }
    }

    private void SpawnBall()
    {
        if (_spawnedBall == null)
        {
            // Если нет, заспавним новый шар
            _spawnedBall = Instantiate(BallPrefab, _positionSpawn, Quaternion.identity);
        }
    }
}
