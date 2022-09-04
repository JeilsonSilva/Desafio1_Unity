using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Animator Animation;
    Rigidbody2D rig;
    Transform trans;
    [SerializeField] Animator anim;

    public Text tx;
    [SerializeField] float speed, jumpForce, x, y;
    [SerializeField] bool isJup, isDJump;
    public static int fruits = 0;

    public int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        Animation = GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();

        trans = GetComponent<Transform>();

       

    }


    // Update is called once per frame
    void Update()
    {

        Animations();
        Move();
        Jump();
        PassarNivel();

    }

    private void PassarNivel()
    {
        if (fruits == totalScore) 
        {
            anim.SetBool("motion", true);

        }
    }

    private void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if (!isJup)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isDJump = true;
            }
            else if (isDJump)
            {
                rig.AddForce(new Vector2(0, jumpForce * 1.5f), ForceMode2D.Impulse);
                isDJump = false;

            }
        }

    }

    private void Move()
    {

        x = Input.GetAxisRaw("Horizontal") * speed;
        y = rig.velocity.y;

        rig.velocity = new Vector2(x, y);

        if (rig.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (rig.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    void Animations()
    {

        if (rig.velocity.x != 0 && !isJup) //run
        {
            Animation.SetFloat("anim", 0.25f);
        }
        else if (isDJump && rig.velocity.y > 0)//Jump
        {
            Animation.SetFloat("anim", 0.5f);
        }
        else if (!isDJump && rig.velocity.y > 0)//DJump
        {
            Animation.SetFloat("anim", 0.75f);
        }
        else if (rig.velocity.y < 0)//Fall
        {
            Animation.SetFloat("anim", 1f);
        }
        else if (rig.velocity.x == 0 && rig.velocity.x == 0)//idle
        {
            Animation.SetFloat("anim", 0f);
        }



    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJup = false;
        }

        if (collision.gameObject.layer == 6 && anim.GetBool("motion"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJup = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Fruit")
        {
            totalScore += 1;
            tx.text = totalScore.ToString();
        }

    }

}

