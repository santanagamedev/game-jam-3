using UnityEngine;

public class LaunchMechanic : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float launchForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Mantiene el objeto en su lugar hasta ser lanzado
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            LaunchTowardsCursor();
        }
    }

    private void LaunchTowardsCursor()
    {
        rb.isKinematic = false; // Activa la física para realizar el lanzamiento

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Obtiene la posición del cursor en el mundo
        Vector2 launchDirection = (mousePosition - rb.position).normalized; // Calcula la dirección de lanzamiento
        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse); // Aplica la fuerza en la dirección del cursor
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Resetea la posición tras el impacto si es necesario
        Invoke("ResetPosition", 2f);
    }

    private void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.position = Vector2.zero; // Ajusta a la posición inicial deseada
        rb.isKinematic = true;
    }
}