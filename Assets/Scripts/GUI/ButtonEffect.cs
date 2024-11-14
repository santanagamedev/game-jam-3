using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material materialButton;
    public float hoverIntensity = 0f; // Intensidad del efecto cuando el mouse está encima
    private float normalIntensity = 1.0f; // Intensidad normal sin hover
    // Start is called before the first frame update
    void Start()
    {
        materialButton = GetComponent<Image>().material;
        materialButton = Instantiate(materialButton);
        GetComponent<Image>().material = materialButton;
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Al hacer hover, establece la intensidad del efecto
        if (materialButton != null)
        {
            materialButton.SetFloat("_HoverIntensity", 0);
        }

    }


    public void OnPointerExit(PointerEventData eventData)
    {

        if (materialButton != null)
        {
            // Al salir, restablece la intensidad a la normal
            materialButton.SetFloat("_HoverIntensity", normalIntensity);
        }

    }
}
