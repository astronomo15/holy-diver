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
}
