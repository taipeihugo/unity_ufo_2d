using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    private int count;

    public Text countText;
    public Text winText;

    private Rigidbody2D rBody;       

    void Start()
    {
        //取得組件<剛體2D>
        rBody = GetComponent<Rigidbody2D>();
        countText.text = "";
        winText.text = "";
    }
    
    void FixedUpdate()
    {
        //A, D, right arrow, left arrow
        float horizontalInput = Input.GetAxis("Horizontal");
        //W, S, 
        float verticalInput = Input.GetAxis("Vertical");

        rBody.AddForce(new Vector2(horizontalInput, verticalInput) * speed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Pickup"))
        {
            Destroy(target.gameObject);
            Count();
        }
    }

    void Count()
    {
        count = count + 1;
        countText.text = "Count: " + count.ToString();

        if (count >= 8) 
        {
            winText.text = "You Win!";
        }

    }//Count

}//class
