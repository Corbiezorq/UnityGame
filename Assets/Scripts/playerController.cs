using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class playerController : MonoBehaviour
{
    private Animator animator;
    private bool moveOk = true;
    public GameObject monster;
    private int vie;
    public AudioClip impact;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        monster = GameObject.Find("monster");
        animator = (Animator)this.GetComponent(typeof(Animator));
        vie = 3;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == monster)
        {
            vie = vie - 1;
            audio.Play();
            Debug.Log(vie);
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