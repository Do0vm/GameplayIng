using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // Start is called before the first frame update

    private float JumpPadStrength = 15f;

    public Sprite springboardUp;
    public Sprite springboardDown;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPadStrength), ForceMode2D.Impulse);

            GetComponent<SpriteRenderer>().sprite = springboardUp;

        }

        else
        {
            GetComponent<SpriteRenderer>().sprite = springboardDown;

        }
    }

    //Add a time dialation effect when using the jumpad

}
