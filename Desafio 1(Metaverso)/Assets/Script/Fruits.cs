using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D cir;
    
    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cir = GetComponent<CircleCollider2D>();
        PlayerMovement.fruits++;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            cir.enabled = false;
            collected.SetActive(true);

          
            Destroy(gameObject,0.25f);
        }

    }   
}
