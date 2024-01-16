using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBallUp : MonoBehaviour
{
    public void ScaleUp(float scaleSpeed)
    {
        Vector3 newScale = transform.localScale + Vector3.one * scaleSpeed * Time.deltaTime;
        transform.localScale = newScale;
    }
}
