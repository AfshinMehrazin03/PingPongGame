using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public string axisName = "Vertical"; // برای راکت چپ از Vertical و برای راست از Vertical2 استفاده کن
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float moveInput = Input.GetAxis(axisName);
        rb.velocity = new Vector2(0, moveInput * speed);
    }
}
