using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    [HideInInspector] // needs to be accessible not in the inspector tab
    public float speed;
    private Rigidbody2D myBody;


    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y); // (velocity x, and velocity y) only use speed on x
    }




} // class
