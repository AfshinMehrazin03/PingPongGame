using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 5f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }
    
    void LaunchBall()
    {
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(-0.5f, 0.5f);
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.velocity = direction * initialSpeed;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // افزایش سرعت بعد از برخورد با راکت
            rb.velocity *= 1.05f;
            
            // تغییر جهت بر اساس نقطه برخورد
            float hitPoint = transform.position.y - collision.transform.position.y;
            float paddleHeight = collision.collider.bounds.size.y;
            float normalizedHitPoint = hitPoint / (paddleHeight / 2);
            
            Vector2 newDirection = new Vector2(
                rb.velocity.x > 0 ? -1 : 1,
                normalizedHitPoint
            ).normalized;
            
            rb.velocity = newDirection * rb.velocity.magnitude;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LeftGoal"))
        {
            FindObjectOfType<GameManager>().ScoreRight();
            ResetBall();
        }
        else if (other.gameObject.CompareTag("RightGoal"))
        {
            FindObjectOfType<GameManager>().ScoreLeft();
            ResetBall();
        }
    }
    
    void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        Invoke("LaunchBall", 1f);
    }
}
