using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float JumpPadStrength;
    //[SerializeField] private float timeDilationFactor = 0.05f;
    //[SerializeField] private float timeDilationDuration = 0.1f;

    //private Rigidbody2D _rigidbody;
    //private bool jump = false, isGrounded = false;



    [Header("Sprites")]
    [SerializeField] public Sprite springboardUp;
    [SerializeField] public Sprite springboardDown;



    private void Awake()
    {
        //_rigidbody = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPadStrength), ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().sprite = springboardUp;

            //StartCoroutine(ApplyTimeDilation());
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = springboardDown;
        }
    }

    //private System.Collections.IEnumerator ApplyTimeDilation()
    //{
    //    _rigidbody.gravityScale = timeDilationFactor; 
    //    Time.fixedDeltaTime = 0.02f * Time.timeScale; 

    //    yield return new WaitForSecondsRealtime(timeDilationDuration); 

    //    Time.timeScale = 1f; 
    //    Time.fixedDeltaTime = 0.02f; 
    //}
}
