﻿using UnityEngine;
using System.Collections;

public class Scp096 : MonoBehaviour
{
    Scp scp
    {
        get => GetComponent<Scp>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scp.Kill();
    }

    private void OnDestroy()
    {
        Debug.Log("scp 096 is die");
    }

    private void OnCollisionStay(Collision collision)
    {
        scp.Kill();
        transform.Rotate(0, Random.Range(-100, 100), 0);
    }
}
