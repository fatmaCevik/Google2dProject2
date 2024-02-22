using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Animator anim;

    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        /*
            rb2D = GetComponent<Rigidbody2D>(); Caching
            anim = GetComponent<Animator>(); Caching
        */
        //started = true;
        grounded = true;
    }

    private void Update()
    {
        CharacterStatus();
    }

    private void FixedUpdate()
    {
        CharacterMove();
    }

    private void CharacterStatus()
    { 
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("Jumping");
            if (started && grounded)
            {
                anim.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                anim.SetBool("GameStarted", true);
                started = true;
            }
        }

        anim.SetBool("Grounded", grounded);
    }

    private void CharacterMove()
    {
        if (started)
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
        }

        if (jumping)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }
}
