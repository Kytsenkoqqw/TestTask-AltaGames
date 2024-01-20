using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerBehaviour : MonoBehaviour, IPlayerBehaviour
{
    [Inject] private DiContainer _diContainer;
    [SerializeField] private float _scalseSpeed;
    public event Action OnPushBall;
    public GameObject BallPrefab;
    private Vector3 _positionSpawn;
    private MoveBall _spawnedBall;
    private ScaleBallUp _scriptScaleBallUp;

    private void Start()
    {
        _positionSpawn = new Vector3(transform.position.x + 6,transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (_spawnedBall != null &&_spawnedBall.IsMoved)
        {
            return;    
        }
        
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            SpawnBall();
        }

        if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            _scriptScaleBallUp.ScaleUp(_scalseSpeed);
            ScaleDown(_scalseSpeed);
        }
        
        if (Input.GetMouseButtonUp(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            OnPushBall?.Invoke();
        }
    }

    private void SpawnBall()
    {
        if (_spawnedBall == null)
        {
            // Если нет, заспавним новый шар
            _spawnedBall = _diContainer.InstantiatePrefab(BallPrefab, _positionSpawn, Quaternion.identity, null).GetComponent<MoveBall>();
            _scriptScaleBallUp = _spawnedBall.GetComponent<ScaleBallUp>();
        }
    }

    private void ScaleDown(float scaleSpeed)
    {
        Vector3 newScale = transform.localScale - Vector3.one * scaleSpeed * Time.deltaTime;
        transform.localScale = newScale;

        if (newScale.x <= 0.1f)
        {
            Time.timeScale = 0f;
        }
    }
}
