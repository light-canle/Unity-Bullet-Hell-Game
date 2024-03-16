using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestoryer : MonoBehaviour
{
    private float activeTime;
    // Start is called before the first frame update
    private void OnEnable()
    {
        activeTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTime >= 1.0f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            activeTime += Time.deltaTime;
        }
    }
}
