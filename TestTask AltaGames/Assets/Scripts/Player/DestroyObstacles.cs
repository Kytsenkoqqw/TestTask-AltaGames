using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class DestroyObstacles : MonoBehaviour
    {
        private bool _onCollision = false;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Obstacle>())
            {
                Debug.Log("Collision");
                _onCollision = true;
            }
        }

        private void OnTriggerStay(Collider collider)
        {
            if (collider.gameObject.GetComponent<Obstacle>() && _onCollision == true) 
            {
                Debug.Log("Trigger");
                StartCoroutine(DestroyWait());
                Destroy(gameObject);
                Destroy(collider.gameObject);
            }
        }

        private IEnumerator DestroyWait()
        {
            yield return new WaitForSeconds(0.25f);
        }
    }
}