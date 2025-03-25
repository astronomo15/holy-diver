using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private int badItemCount = 0;
    private int score = 0; // Pontua��o

    public float minX = -7f; // Limite esquerdo
    public float maxX = 7f;  // Limite direito

    public GameObject gameOverPanel; // Painel de Game Over
    public TextMeshProUGUI scoreText; // Texto da pontua��o

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); // Pegando entrada do jogador
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Mant�m o player dentro dos limites
        float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
        rb.position = new Vector2(clampedX, rb.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoodItem"))
        {
            score += 10; // Aumenta a pontua��o
            UpdateScoreText();
            Destroy(other.gameObject);
            SpawnManager.Instance.SpawnItems(); // Spawna novos itens
        }
        else if (other.CompareTag("BadItem"))
        {
            Destroy(other.gameObject);
            badItemCount++;

            if (badItemCount >= 3)
            {
                GameOver();
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Pontuacao: " + score;
    }

    void GameOver()
    {
        Time.timeScale = 0; // Para o jogo
        gameOverPanel.SetActive(true); // Mostra o painel de Game Over
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Volta ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
