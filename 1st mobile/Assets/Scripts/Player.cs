using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    public LayerMask ground;
    public LayerMask deathGround;
    private Collider2D playerollider;
    private Animator animator;

    public AudioSource deathSound;
    public AudioSource jumpSound;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplier;
    public GameManager gameManager;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();    
        playerollider= GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }

    // Update is called once per frame
    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(playerollider, deathGround);
        if(dead)
        {
            GameOver();
        }


        if (transform.position.x>mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplier;
            mileStone += mileStone * speedMultiplier;
            Debug.Log("M" + mileStone + ", MC" + mileStoneCount + ", MS" + speed);
        }



        rb.velocity=new Vector2(speed,rb.velocity.y);
        bool grounded=Physics2D.IsTouchingLayers(playerollider,ground);

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {if(grounded)
            {   jumpSound.Play(); 
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
            
        }
        animator.SetBool("Grounded", grounded);
    }
    void GameOver()
    {
        gameManager.GameOver();
    }
}
