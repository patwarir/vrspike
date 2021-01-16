using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeMap : MonoBehaviour
{
    public Vector3 scaleSize;
    private bool setScale = false;
    void Update()
    {
        if (!setScale)
        {
            transform.localScale = scaleSize;
            setScale = true;
        }
    }
}
