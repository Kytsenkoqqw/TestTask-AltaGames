using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBallUp : MonoBehaviour
{
    [SerializeField] private float _maxScale = 5f;

    public void ScaleUp(float scaleSpeed)
    {
        Vector3 newScale = transform.localScale + Vector3.one * scaleSpeed * Time.deltaTime;
        newScale = Vector3.Min(newScale, Vector3.one * _maxScale);
        transform.localScale = newScale;
    }
}
