using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PushBall : MonoBehaviour
    {
        public event Action OnLoseMenu;
        [SerializeField] private float _speed;
        private Coroutine _pushStartCoroutine;
        private Vector3 _roadBall = new Vector3(1,0,0);

        public void StartMove()
        {
            if (_pushStartCoroutine == null)
            {
                _pushStartCoroutine = StartCoroutine(PushBigBall());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Finish>())
            {
                Debug.Log("Finish");
                Destroy(gameObject);
            }

            if (collision.gameObject.GetComponent<Obstacle>())
            {
                Debug.Log("Obstacle");
                OnLoseMenu?.Invoke();
                Destroy(gameObject);
            }
        }
        
        private  IEnumerator PushBigBall()
        {
            while (gameObject)
            {
                transform.Translate(_roadBall * _speed * Time.deltaTime);
                yield return null;
            }
        }
    }
    
    
}