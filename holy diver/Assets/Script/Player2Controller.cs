using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float limiteEsquerdo = -3f;
    public float limiteDireito = 3f;

    private Rigidbody2D rb;
    private float movimento;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Garante que o player não caia
        rb.freezeRotation = true; // Evita rotação inesperada
    }

    private void Update()
    {
        movimento = Input.GetAxisRaw("Horizontal2"); // Remove suavização do Input
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimento * PlayerController.velocidade, rb.linearVelocity.y);

        // Impedir o player de sair dos limites
        float clampedX = Mathf.Clamp(rb.position.x, limiteEsquerdo, limiteDireito);
        rb.position = new Vector2(clampedX, rb.position.y);
    }
}
