using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float leftLimit = -3f;
    [SerializeField] private float rightLimit = 3f;
    [SerializeField] private string inputName;

    private Rigidbody2D rb;
    private float moveInput;
    private PlayerStats stats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        moveInput = Input.GetAxisRaw(inputName);
    }

    private void FixedUpdate()
    {
        float currentSpeed = stats.GetSpeed();
        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);

        float clampedX = Mathf.Clamp(rb.position.x, leftLimit, rightLimit);
        rb.position = new Vector2(clampedX, rb.position.y);
    }
}
