﻿using UnityEngine;
using System.Collections;

public class O5Card : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        if (-3 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 3
            && -3 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 3
            && Input.GetKey(KeyCode.E))
        {
            player.GetComponent<Player>().level = SecurityLevel.O5;
            Destroy(gameObject);
        }
    }
}