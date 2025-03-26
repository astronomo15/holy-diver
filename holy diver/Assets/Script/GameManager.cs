using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pontuacao = 0;
    public int erros = 0;
    public int errosParaGameOver = 3;

    public Text pontuacaoText;
    public GameObject gameOverPanel;

    public void AdicionarPontuacao(int pontos)
    {
        pontuacao += pontos;
        pontuacaoText.text = "Pontuação: " + pontuacao;
    }

    public void RegistrarErro()
    {
        erros++;
        if (erros >= errosParaGameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}