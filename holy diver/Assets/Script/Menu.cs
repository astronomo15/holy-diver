using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

}