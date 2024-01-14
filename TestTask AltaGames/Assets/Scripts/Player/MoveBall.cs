using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class MoveBall : MonoBehaviour
    {
        public bool IsMoved => _pushStartCoroutine != null;
        private Coroutine _pushStartCoroutine;
        [Inject] private IPlayerBehaviour _playerBehaviour;
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
            if (_pushStartCoroutine == null)
            {
                _pushStartCoroutine = StartCoroutine(PushStart());
            }
        }

        private  IEnumerator PushStart()
        {
            while (gameObject)
            {
                transform.Translate(_roadBall * _speed * Time.deltaTime);
                yield return null;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Finish>())
            {
                Destroy(gameObject);
            }
        }
    }
}