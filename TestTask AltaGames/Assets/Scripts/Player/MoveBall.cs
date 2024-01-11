using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoveBall : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour _playerBehaviour;
        private Vector3 _roadBall = new Vector3(1,0,0);
        [SerializeField] private float _speed;

        private void Start()
        {
            _playerBehaviour.OnPushBall += BallMove;
        }

        private void OnDestroy()
        {
            _playerBehaviour.OnPushBall -= BallMove;
        }

        private void BallMove()
        {
            transform.Translate(_roadBall * _speed * Time.deltaTime);
        }
    }
}