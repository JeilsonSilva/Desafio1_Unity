using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Plats : MonoBehaviour
{

    public float fallingTime;
    private TargetJoint2D target;
    private BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        coll = GetComponent<BoxCollider2D>();
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", fallingTime);
                  
        }

    }

    void Fall()
    {
        target.enabled = false;
        coll.isTrigger = true;

    }
}
