using System.Collections;
using UnityEngine;

public class DamageTransition : MonoBehaviour
{
    [SerializeField] private Material normalMaterial;     // Material del estado normal del personaje
    [SerializeField] private Material damageMaterial;     // Material de daño con el efecto de borde rojo
    [SerializeField] private MeshRenderer characterRenderer;  // Renderer del personaje
    public float transitionSpeed = 1.0f;
    public float effectDuration = 0.5f; // Duración de la transición del efecto de daño

    private float damageIntensity = 1.0f;
    private bool isDamaged = false;

    void Start()
    {
        // Seleccionamos el componente Renderer del Player
        characterRenderer = transform.GetComponent<MeshRenderer>();

        // Configura el Renderer para que use ambos materiales
        characterRenderer.materials = new Material[] { normalMaterial, damageMaterial };

        // Inicia con el efecto de daño desactivado
        damageMaterial.SetFloat("_DamageIntensity", 1.0f);
    }

    public void Damaged(float damage)
    {
        damageIntensity = 1.0f;

        // Inicia la corutina de efecto de daño
        StartCoroutine(DamageEffectCoroutine());
    }

    private IEnumerator DamageEffectCoroutine()
    {
        // Configura la intensidad inicial al máximo
        damageIntensity = 1.0f;
        damageMaterial.SetFloat("_DamageIntensity", damageIntensity);

        // Gradualmente reduce la intensidad del efecto de daño
        while (damageIntensity > 0)
        {
            damageIntensity -= Time.deltaTime * transitionSpeed;
            damageMaterial.SetFloat("_DamageIntensity", Mathf.Clamp01(damageIntensity));
            yield return null; // Espera hasta el siguiente frame
        }

        // Asegúrate de que el efecto esté completamente apagado
        damageMaterial.SetFloat("_DamageIntensity", 0);
    }
}