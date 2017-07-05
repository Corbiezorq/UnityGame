﻿using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    private Animator animator;
    private bool moveOk = true;

    // Use this for initialization
    void Start()
    {
        animator = (Animator)this.GetComponent(typeof(Animator));
    }

    // Movement speed
    public float speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (moveOk == true)
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            ManageMovement(h, v);
        }
        else
        {
            stopMovement();
        }
    }

    void stopMovement()
    {
        animator.SetBool("moving", false);

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    void ManageMovement(float horizontal, float vertical)
    {

        if (horizontal != 0f || vertical != 0f)
        {
            animator.SetBool("moving", true); animateWalk(horizontal, vertical);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0);
        GetComponent<Rigidbody2D>().velocity = movement*speed;
    }

    void animateWalk(float h, float v)
    {
        if (animator)
        {
            if ((v > 0) && (v > h))
            {
                animator.SetInteger("direction", 1);
            }
            if ((h > 0) && (v < h))
            {
                animator.SetInteger("direction", 2);
            }
            if ((v < 0) && (v < h))
            {
                animator.SetInteger("direction", 3);
            }
            if ((h < 0) && (v > h))
            {
                animator.SetInteger("direction", 4);
            }
        }
    }

    public void setMoveOk(int move)
    {
        if (move == 1)
        {
            moveOk = true;
        }

        else if (move == 0)
        {
            moveOk = false;
        }

    }

    public bool getMoveOk()
    {
        return moveOk;
    }
}