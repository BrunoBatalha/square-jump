using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnLost;

    [SerializeField]
    private float jumpForce;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool isJumping;
    private float initialX;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < initialX)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if ((Input.GetKeyDown(KeyCode.Space) ||
             Input.GetKeyDown(KeyCode.UpArrow) ||
             Input.GetKeyDown(KeyCode.W) ||
             ClickRightScreen()) && !isJumping)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if ((Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.DownArrow) ||
            ClickLeftScreen()) && isJumping)
        {
            rigidbody2D.AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
        }

        if (rigidbody2D.velocity.y > 0F)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }
        if (rigidbody2D.velocity.y < 0F)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }
    }

    private bool ClickRightScreen()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position.x > Screen.width / 2;
        }
        return false;
    }

    private bool ClickLeftScreen()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position.x < Screen.width / 2;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            animator.SetBool("isFalling", false);
            animator.SetBool("isJumping", false);
        }

        if (collision.gameObject.layer == 3)
        {
            OnLost();
        }
    }
}
