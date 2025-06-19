using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerController: MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    [SerializeField] private float speed;
    [SerializeField] private int maxJumps;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private float spriteTime;
    private bool grounded;
    private int jumpCount;

    private void Awake()
    {
        // run on 0th frame

        // this is how you get your rigidbody
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = true;
            jumpCount = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = false;

        }
    }

    private IEnumerator ShowSprite()
    {
        sr.sprite = sprites[1];
        yield return new WaitForSecondsRealtime(spriteTime);

        sr.sprite = sprites[0];
    }

    private void Update()
    {
        // this is like a while loop, be careful

        // WASD movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
        }
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    rb.AddForce(Vector2.up * speed);
        //}
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector2.down * speed);
        }
        if (Input.GetKeyUp(KeyCode.Space) && (grounded || jumpCount < maxJumps))
        {
            rb.AddForce((Vector2.up * speed) * 5);
            jumpCount++;
            
        }
        if (Input.GetMouseButton(0))
        {
            StopAllCoroutines();
            StartCoroutine(ShowSprite());
        }
    }
}
