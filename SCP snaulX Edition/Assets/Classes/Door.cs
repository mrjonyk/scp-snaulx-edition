﻿using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public byte axis;
    public float seconds;
    float x, z;
    public SecurityLevel level;
    public bool Lock;
    new AudioSource audio;
    private bool player_can_open = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("DoorSound").GetComponent<AudioSource>();
        x = transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds <= 0 && seconds != -1)
        {
            Close();
        }
        else
        {
            seconds = seconds - Time.deltaTime * 80;
        }
        try
        {
            GameObject player = GameObject.Find("player");
            if (-4 < player.transform.position.z - transform.position.z && player.transform.position.z - transform.position.z < 4
                && -4 < player.transform.position.x - transform.position.x && player.transform.position.x - transform.position.x < 4)
            {
                player_can_open = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (player.GetComponent<Player>().level >= level)
                    {
                        Open();
                    }
                    else
                    {
                        audio.Play();
                    }
                }
            }
            else
            {
                player_can_open = false;
            }
        }
        catch (NullReferenceException)
        {
            //лол почему
        }
    }

    public void Close()
    {
        if (!Lock)
        {
            try
            {
                //AudioSource close = GetComponents<AudioSource>()[1];
                //close.PlayOneShot(close.clip);
            }
            catch { }
            transform.position = new Vector3(x, transform.position.y, z);
        }
    }

    public void Open()
    {
        if (!Lock)
        {
            try
            {
                //AudioSource open = GetComponents<AudioSource>()[0];
                //open.PlayOneShot(open.clip);
                if (axis == 0) GetComponent<Animator>().Play("top");
                else if (axis == 1) GetComponent<Animator>().Play("bottom");
                else if (axis == 2) GetComponent<Animator>().Play("left");
                else GetComponent<Animator>().Play("right");
            }
            catch
            {
                //if door haven`t animation
                for (float i = 0; i < 6f; i += 0.001f)
                {
                    //движение двери относительно стартовой позиции персонажа
                    if (axis == 0) transform.position = new Vector3(x - i, transform.position.y, z); //left
                    else if (axis == 1) transform.position = new Vector3(-x - i, transform.position.y, z); //right
                    else if (axis == 2) transform.position = new Vector3(x, transform.position.y, z - i); //top
                    else transform.position = new Vector3(x, transform.position.y, -z - i); //back
                }
            }
            seconds = 100;
        }
    }

    public void Unlock()
    {
        Lock = false;
        Open();
    }
    public void Lockdown()
    {
        Lock = true;
        Close();
    }

    private void OnGUI()
    {
        if (player_can_open)
        {
            GUI.DrawTexture(new Rect(400, 400, 60, 60), GameObject.Find("player").GetComponent<Main>().handsymbol);
        }
    }
}
