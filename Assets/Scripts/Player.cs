using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // allows variables to be visible in inspector panel but are still private and cannot be accessed by other classes
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 100f;
    private float movementX;
    // [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    // called every fixed framerate
    private void FixedUpdate() 
    {
        //PlayerJump();  doesn't work here
    }
    
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); // gets input from left and right keys -1 , 0, 1

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

    }

    void AnimatePlayer()
    {
        //we are going to the right
        if (movementX > 0) 
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        // we are going to the left
        else if (movementX < 0) 
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } 
        else 
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump() 
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // GetButton or Up/Down
        { 
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // want to apply force on the y axis so Vector2 and x = 0. Add an instant force impulse tothe rigid body using its mass
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) // if an if statement has one single line of code you can omit curly brackets
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision) // isTrigger must be checked in box collider
    {
        if (collision.CompareTag(ENEMY_TAG)) // collider2d tag can access compare tag right away, but not collision2d
            Destroy(gameObject);
    }


} // class


