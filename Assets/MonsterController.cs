using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = (Animator)this.GetComponent(typeof(Animator));
        StartCoroutine("DoCheck");
    }

    // Movement speed
    public float speed = 1;

    IEnumerator DoCheck()
    {
        for (;;)
        {
            int dir = Random.Range(1, 5);
            ManageMovement(dir);
            yield return new WaitForSeconds(1f);
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

    void animateWalk(int dir)
    {
        if (animator)
        {
            animator.SetInteger("direction", dir);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Made A collision");
    }
}
