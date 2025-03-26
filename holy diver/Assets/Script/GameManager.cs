using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SpawnManager spawnManager; // Refer�ncia ao SpawnManager
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // Fun��o que � chamada para aumentar a pontua��o
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Fun��o para exibir a pontua��o no UI
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    // Fun��o chamada quando o Player 1 perde
    public void PlayerGameOver(int playerNumber)
    {
        Debug.Log("Game Over para o Player " + playerNumber);
        // L�gica para finalizar o jogo ou reiniciar a cena
    }
}
