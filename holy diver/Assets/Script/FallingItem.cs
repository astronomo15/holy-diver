using UnityEngine;

public class FallingItem : MonoBehaviour
{
    public float fallSpeed = 3f; // Velocidade da queda

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroi o objeto se sair da tela
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}