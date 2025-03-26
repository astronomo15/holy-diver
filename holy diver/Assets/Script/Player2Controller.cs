using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento
    private Rigidbody2D rb;  // Referência ao Rigidbody2D
    private float moveInput;  // Entrada de movimento

    public float leftLimit = 0f;  // Limite esquerdo da tela para Player 2 (metade da tela)
    public float rightLimit = 7f;  // Limite direito da tela para Player 2

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtém o Rigidbody2D
    }

    void Update()
    {
        // Movimentação do Player 2 com as teclas J/K
        moveInput = Input.GetAxisRaw("Horizontal2");  // Configurar no Input Manager

        // Movimentação do Player 2
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Só altera a posição no eixo X

        // Limita a posição do Player 2 entre os limites da metade direita da tela
        float clampedX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoodItem"))
        {
            GameManager.Instance.AddScore(2); // Pontos para o Player 2
            Destroy(other.gameObject);
            SpawnManager.Instance.SpawnItems();  // Re-spawn de item bom
        }
        else if (other.CompareTag("BadItem"))
        {
            GameManager.Instance.PlayerGameOver(2); // Game over para o Player 2
        }
    }
}
