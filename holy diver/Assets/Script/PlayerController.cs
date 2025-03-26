using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float minX = -7f;  // Limite da esquerda
    public float maxX = 7f;   // Limite da direita
    public GameManager gameManager;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimentação do Player com as teclas A/D
        float move = Input.GetAxis("Horizontal"); // A/D para Player 1
        rb.linearVelocity = new Vector2(move * speed, 0);

        // Limita o movimento do player
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    // Detecta a colisão com itens
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoodItem"))
        {
            // Aumenta a pontuação quando o Player 1 coleta um item bom
            GameManager.Instance.AddScore(1);
            Destroy(other.gameObject);
            SpawnManager.Instance.SpawnItems(); // Garantir que spawnem novos itens
        }
        else if (other.CompareTag("BadItem"))
        {
            // Chama a função de GameOver quando o Player 1 coleta um item ruim
            GameManager.Instance.PlayerGameOver(1);
        }
    }
}
