using UnityEngine;
using System.Collections;

public class PlayerLowFuelEffect : MonoBehaviour
{
    [SerializeField] private Material playerMaterial; // Material del shader del jugador
    private float maxFuelIntensity = 1.0f; // Máxima intensidad de daño
    private float minFuelIntensity = 0.0f; // Intensidad mínima (sin efecto)
    [SerializeField] private float effectDuration = 2.0f; // Duración del efecto en segundos

    void Start()
    {
        // Obtén el material del componente del jugador (por ejemplo, un SpriteRenderer)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            playerMaterial = spriteRenderer.material;
        }
        else
        {
            Debug.LogWarning("No se encontró un componente SpriteRenderer en el objeto.");
        }
    }

    // Función para activar el efecto de daño
    public void ActivateLowFuelEffect()
    {
        if (playerMaterial != null)
        {
            playerMaterial.SetFloat("_Damage", maxFuelIntensity); // Activa el efecto de daño
            StartCoroutine(DeactivateLowFuelEffectAfterTime(effectDuration)); // Llama a la corrutina para desactivarlo después de unos segundos
        }
    }

    // Corrutina para desactivar el efecto después de un cierto tiempo
    private IEnumerator DeactivateLowFuelEffectAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration); // Espera durante el tiempo especificado
        if (playerMaterial != null)
        {
            playerMaterial.SetFloat("_Damage", minFuelIntensity); // Desactiva el efecto de daño
        }
    }

    // Opcional: Ajusta el valor de _Damage a un valor personalizado
    public void SetDamageIntensity(float intensity)
    {
        if (playerMaterial != null)
        {
            playerMaterial.SetFloat("_Damage", Mathf.Clamp(intensity, minFuelIntensity, maxFuelIntensity));
        }
    }
}