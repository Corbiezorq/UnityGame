using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    private Animator animator;
    private bool detecte = false;
    private bool moveOk = true;
    public GameObject player;
    public GameObject monster;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        monster = GameObject.Find("monster");
        animator = (Animator)this.GetComponent(typeof(Animator));
        StartCoroutine("DoCheck");
    }

    // Movement speed
    public float speed = 1;

    IEnumerator DoCheck()
    {
        for (;;)
        {
            
            if (detecte == false && moveOk == true)
            {
                int dir = Random.Range(1, 5);
                ManageMovement(dir);
                yield return new WaitForSeconds(1F);
            }
            else if(detecte == true && moveOk == true)
            {
                //dynamicColorObject.monster.sharedMaterial.color = Color.red;
                float player_x = player.transform.position.x;
                float player_y = player.transform.position.y;

                FollowMovement(player_x, player_y);
                yield return new WaitForSeconds(0.001F);
            }
            else if (moveOk == false)
            {
                stopMovement();
                yield return new WaitForSeconds(1F);
            }
        }
         
    }

    void FollowMovement(float player_x, float player_y)
    {
        if (transform.position.x > player_x && transform.position.y > player_y)
        {
            Vector3 movement = new Vector3(-1, -1, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            animateFollow(4);
        }
        if (transform.position.x > player_x && transform.position.y < player_y)
        {
            Vector3 movement = new Vector3(-1, 1, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            animateFollow(4);
        }
        if (transform.position.x < player_x && transform.position.y > player_y)
        {
            Vector3 movement = new Vector3(1, -1, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            animateFollow(2);
        }
        if (transform.position.x < player_x && transform.position.y < player_y)
        {
            Vector3 movement = new Vector3(1, 1, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            animateFollow(2);
        }
        if ( player_x +0.5 > transform.position.x && player_x -0.5 < transform.position.x && transform.position.y < player_y)
        {
            Vector3 movement = new Vector3(0, 1, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            animateFollow(1);
        }
        if (player_x + 0.5 > transform.position.x && player_x - 0.5 < transform.position.x && transform.position.y > player_y)
        {
            Vector3 movement = new Vector3(0, -1, 0);
            GetComponent<Rigidbody2D>().velocity = movement * speed;
            animateFollow(3);
        }

    }

    void ManageMovement(int dir)
    {
        animator.SetBool("moving", true); animateWalk(dir);

        if(dir == 1)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        }
        else if (dir == 2)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
        else if (dir == 3)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        }
        else if (dir == 4)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }

    }

    void stopMovement()
    {
        animator.SetBool("moving", false);

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }

    void animateWalk(int dir)
    {
        if (animator)
        {
            animator.SetInteger("direction", dir);
        }
    }

    void animateFollow(int dirr)
    {
        Debug.Log(dirr);
        if (animator)
        {
            if ( dirr == 1 )
            {
                // up
                animator.SetInteger("direction", 1);
            }
            if (dirr == 2)
            {
                // right
                animator.SetInteger("direction", 2);
            }
            if (dirr == 3)
            {
                // down
                animator.SetInteger("direction", 3);
            }
            if (dirr == 4)
            {
                // left
                animator.SetInteger("direction", 4);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        detecte = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detecte = false;
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
