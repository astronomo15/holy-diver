using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 5f;
    public float limiteX = 3f;

    private void Update()
    {
        float move = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.position += new Vector3(move, 0, 0);

        // Limitar movimento dentro da tela
        float clampedX = Mathf.Clamp(transform.position.x, -limiteX, limiteX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}