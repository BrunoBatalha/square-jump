using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnLost;
    
    [SerializeField]
    private float jump;

    private Rigidbody2D _rigidbody2D;
    private bool _isJumping;
    private float initialX;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < initialX)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !_isJumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            _isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rigidbody2D.AddForce(new Vector2(0f, -jump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            _isJumping = false;
        }

        if(collision.gameObject.layer == 3)
        {
            OnLost();
            //GameManager.instance.ShowGameOver();
        }
    }
}
