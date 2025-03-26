using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public SpawnManager spawnManager; // Referência ao SpawnManager
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

    // Função que é chamada para aumentar a pontuação
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Função para exibir a pontuação no UI
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    // Função chamada quando o Player 1 perde
    public void PlayerGameOver(int playerNumber)
    {
        Debug.Log("Game Over para o Player " + playerNumber);
        // Lógica para finalizar o jogo ou reiniciar a cena
    }
}
