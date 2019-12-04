﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Vector2 position;
    public Animator animator;
    private string moveLock;
    public int dashmultiplyer;
    private bool islocked;
    private double unlocktime;
    private int unlockkey;
    public int jumpmultiplyer;
    private int timeint;
    // Use this for initialization
    void Start()
    {
        position = gameObject.transform.position;
        animator = GetComponent<Animator>();
        Application.targetFrameRate = 60;
        islocked = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        timeint = (int)Time.time;
        if (Input.GetKey(KeyCode.D) || unlockkey == 3)
        {
            
            if (Input.GetKeyDown(KeyCode.LeftShift) || unlockkey == 3)
            {
                Movementlock(0.25, 3);
                ZachMovement(Vector2.right, ((float)unlocktime - Time.time) * dashmultiplyer, 3);
            }
            else
            {
                ZachMovement(Vector2.right, speed, 1);
            }
        }
        else if (Input.GetKey(KeyCode.A) || unlockkey == 4)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || unlockkey == 4)
            {
                Movementlock(0.25, 4);
                ZachMovement(Vector2.left, ((float)unlocktime - Time.time) * dashmultiplyer, 4);
            }
            else
            {
                ZachMovement(Vector2.left, speed, 2);
            }
        }
        else if (Input.GetKey(KeyCode.W) || unlockkey == 5)
        {
            Movementlock(0.5, 5);
            if (Time.time >= unlocktime - .25 && islocked)
            {
                ZachMovement(Vector3.down, speed * jumpmultiplyer, 5);
            }
            else if(Time.time <= unlocktime - .25 && islocked)
            {
                ZachMovement(Vector3.up, speed * jumpmultiplyer, 5);
            }
        }
        else if (!islocked)
        {
            animator.SetInteger("AnimationState", 0);
        }

    }
     void ZachMovement(Vector3 zachdirection, float zachspeed, int animationstate)
    {
        if (!islocked || animationstate == unlockkey)
        {
            transform.Translate(zachdirection * zachspeed * Time.deltaTime, transform);
            animator.SetInteger("AnimationState", animationstate);
        }
    }

    void Movementlock(double delaytime, int currentkey)
    {
        if(!islocked)
        {
            unlockkey = currentkey;
            islocked = true;
            unlocktime = Time.time + delaytime;
        }
        else if(unlocktime <= Time.time)
        {
            islocked = false;
            unlockkey = 9999;
        }
    }

}