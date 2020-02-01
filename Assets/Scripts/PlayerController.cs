using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rb2d;

    private int count;
    private int lives;

    public Text countText;
    public Text winText;
    public Text nameText;
    public Text livesText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        nameText.text = "";
        SetCountText();
        SetLivesText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
        if (count == 15)
        {
            transform.position = new Vector2(81.75f, -10.0f);
        }
    }
    
    void SetCountText()
    {
        countText.text = "Pickup Count: " + count.ToString();
        if (count >= 27)
        {
            winText.text = "Congratulations! You Win!";
            nameText.text = "Game created by Maxwell Bustamante";
            Destroy(this);
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            winText.text = "You Lose!";
            nameText.text = "Game created by Maxwell Bustamante";
            Destroy(this);
        }
    }
}
