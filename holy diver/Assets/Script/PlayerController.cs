using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    private int badItemCount = 0;
    public TextMeshProUGUI gameOverText;

    public float minX = -7f; // Limite esquerdo
    public float maxX = 7f;  // Limite direito

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(moveX, 0, 0);

        // Mantém o player dentro dos limites
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GoodItem"))
        {
            Destroy(other.gameObject);
            SpawnManager.Instance.SpawnItems();
        }
        else if (other.CompareTag("BadItem"))
        {
            Destroy(other.gameObject);
            badItemCount++;
            SpawnManager.Instance.SpawnItems();

            if (badItemCount >= 3)
            {
                gameOverText.gameObject.SetActive(true);
                Invoke("RestartGame", 2f);
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}